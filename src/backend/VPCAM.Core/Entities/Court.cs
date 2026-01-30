namespace VPCAM.Core.Entities;

public class Court
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? NvrChannelId { get; set; } // Crucial for automation
    public string? RtspUrl { get; set; }

    public Venue? Venue { get; set; }
}
