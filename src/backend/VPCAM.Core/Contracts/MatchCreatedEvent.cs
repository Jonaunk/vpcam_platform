namespace VPCAM.Core.Contracts;

public class MatchCreatedEvent
{
    public int MatchId { get; set; }
    public string SourceUrl { get; set; } = string.Empty;
}
