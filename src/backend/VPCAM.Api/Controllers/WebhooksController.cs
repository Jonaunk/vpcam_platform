using MassTransit;
using Microsoft.AspNetCore.Mvc;
using VPCAM.Core.Entities;
using VPCAM.Api.Infrastructure.Data;
using VPCAM.Core.Contracts;

namespace VPCAM.Api.Controllers;

public record RecordUploadEvent(string DeviceId, string FileUrl); // Payload contract

[ApiController]
[Route("api/webhooks")]
public class WebhooksController : ControllerBase
{
    private readonly IPublishEndpoint _bus;
    private readonly VpcamDbContext _db;

    public WebhooksController(IPublishEndpoint bus, VpcamDbContext db)
    {
        _bus = bus;
        _db = db;
    }

    [HttpPost("dahua")]
    public async Task<IActionResult> Receive([FromBody] RecordUploadEvent evt)
    {
        // 1. Save initial record
        var match = new Match
        {
            Status = MatchStatus.Processing,
            CourtId = 1, // TODO: Map DeviceId to CourtId
            StartTime = DateTime.UtcNow,
            DahuaUrl = evt.FileUrl,
            GlobalId = Guid.NewGuid().ToString()
        };
        
        _db.Matches.Add(match);
        await _db.SaveChangesAsync(); // Get Id
        
        // 2. Publish event for Worker
        await _bus.Publish(new MatchCreatedEvent { MatchId = match.Id, SourceUrl = evt.FileUrl });
        
        return Ok(new { status = "Enqueued", matchId = match.Id });
    }
}

