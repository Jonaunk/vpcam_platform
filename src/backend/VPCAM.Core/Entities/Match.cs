using System;

namespace VPCAM.Core.Entities;

public enum MatchStatus
{
    Scheduled,
    Recording,
    Processing,
    Ready,
    Error
}

public class Match
{
    public int Id { get; set; }
    public int CourtId { get; set; }
    public MatchStatus Status { get; set; }
    public DateTime StartTime { get; set; }
    public string GlobalId { get; set; } = string.Empty; // For deduplication/search
    public string? CdnUrl { get; set; }
    public string? DahuaUrl { get; set; }

    public Court? Court { get; set; }
}
