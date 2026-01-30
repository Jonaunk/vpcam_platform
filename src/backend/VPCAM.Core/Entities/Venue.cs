using System.Collections.Generic;

namespace VPCAM.Core.Entities;

public class Venue
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Location { get; set; }

    public ICollection<Court> Courts { get; set; } = new List<Court>();
}
