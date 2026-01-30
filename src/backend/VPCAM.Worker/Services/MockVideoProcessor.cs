using System;
using System.Threading.Tasks;

namespace VPCAM.Worker.Services;

public interface IVideoProcessor
{
    Task<string> ProcessAsync(string sourceUrl);
}

public class MockVideoProcessor : IVideoProcessor
{
    private readonly ILogger<MockVideoProcessor> _logger;

    public MockVideoProcessor(ILogger<MockVideoProcessor> logger)
    {
        _logger = logger;
    }

    public async Task<string> ProcessAsync(string sourceUrl)
    {
        _logger.LogInformation("Starting download from {Url}...", sourceUrl);
        await Task.Delay(2000); // Simulate Download
        
        _logger.LogInformation("Transcoding to HLS...");
        await Task.Delay(3000); // Simulate FFmpeg
        
        _logger.LogInformation("Uploading to R2...");
        await Task.Delay(1000); // Simulate Upload
        
        // Return dummy HLS URL (Simulating R2 public URL)
        return "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8"; 
    }
}
