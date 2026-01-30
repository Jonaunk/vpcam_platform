using MassTransit;
using Microsoft.EntityFrameworkCore;

// Note: I cannot ref reference VPCAM.Api from VPCAM.Worker if API refs Worker (circular). API refs Worker? No, API refs Core. Worker refs Core.
// But DbContext is in Api. I should have put it in Core or Infrastructure separate lib.
// Fixing this: I will MOVE VpcamDbContext to VPCAM.Core (or create new VPCAM.Infrastructure).
// For speed now: I will assume I can move it or duplicate it.
// Better: I will create VpcamDbContext in VPCAM.Worker (duplicate for MVP) or just move it to VPCAM.Core now.
// Moving to VPCAM.Core requires adding EF Core to VPCAM.Core. 
// I'll Duplicate it in Worker namespace for now to avoid refactoring hell in this step, targeting "Walking Skeleton". 
// Actually, cleanly: I should move it to Core.
// Let's TRY referencing the file from Core if I move it? No.
// I'll make a local VpcamDbContext in Worker.

using VPCAM.Core.Contracts;
using VPCAM.Core.Entities;
using VPCAM.Worker.Data; // Local context
using VPCAM.Worker.Services;

namespace VPCAM.Worker.Consumers;

public class VideoProcessedConsumer : IConsumer<MatchCreatedEvent>
{
    private readonly ILogger<VideoProcessedConsumer> _logger;
    private readonly IVideoProcessor _processor;
    private readonly WorkerDbContext _db;

    public VideoProcessedConsumer(ILogger<VideoProcessedConsumer> logger, IVideoProcessor processor, WorkerDbContext db)
    {
        _logger = logger;
        _processor = processor;
        _db = db;
    }

    public async Task Consume(ConsumeContext<MatchCreatedEvent> context)
    {
        var msg = context.Message;
        _logger.LogInformation("Received Match {Id}", msg.MatchId);

        try 
        {
            var match = await _db.Matches.FindAsync(msg.MatchId);
            if (match == null) 
            {
                _logger.LogError("Match {Id} not found in DB", msg.MatchId);
                return;
            }

            match.Status = MatchStatus.Processing;
            await _db.SaveChangesAsync();

            var hlsUrl = await _processor.ProcessAsync(msg.SourceUrl);

            match.Status = MatchStatus.Ready;
            match.CdnUrl = hlsUrl;
            await _db.SaveChangesAsync();
            
            _logger.LogInformation("Match {Id} PROCESSED. URL: {Url}", msg.MatchId, hlsUrl);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing match {Id}", msg.MatchId);
            // In real app, separate retry policy or Error status
            var m = await _db.Matches.FindAsync(msg.MatchId);
            if (m != null)
            {
                m.Status = MatchStatus.Error;
                await _db.SaveChangesAsync();
            }
        }
    }
}
