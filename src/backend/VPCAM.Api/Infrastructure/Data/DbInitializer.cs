using Microsoft.EntityFrameworkCore;
using VPCAM.Core.Entities;

namespace VPCAM.Api.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(VpcamDbContext context)
    {
        // Wipe old data as per directives
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        if (context.Venues.Any())
        {
            return;   // DB has been seeded
        }

        var venues = new Venue[]
        {
            new Venue 
            { 
                Name = "La Fábrica", 
                Slug = "la-fabrica", 
                ImageUrl = "assets/venues/la-fabrica.jpg", 
                Location = "Córdoba, Argentina",
                Courts = new List<Court>
                {
                    new Court { Name = "Cancha 1", NvrChannelId = 1, RtspUrl = "rtsp://admin:12345@192.168.1.10:554/cam/realmonitor?channel=1&subtype=0" },
                    new Court { Name = "Cancha 2", NvrChannelId = 2, RtspUrl = "rtsp://admin:12345@192.168.1.10:554/cam/realmonitor?channel=2&subtype=0" }
                }
            },
            new Venue 
            { 
                Name = "Antártida Padel", 
                Slug = "antartida-padel", 
                ImageUrl = "assets/venues/antartida.jpg", 
                Location = "San Francisco, Córdoba",
                Courts = new List<Court>
                {
                    new Court { Name = "Central", NvrChannelId = 1 },
                    new Court { Name = "Panorámica", NvrChannelId = 2 },
                    new Court { Name = "Fondo", NvrChannelId = 3 }
                }
            }
        };

        context.Venues.AddRange(venues);
        context.SaveChanges();

        // Seed Matches
        // Need to get IDs after save
        var laFabricaC1 = context.Courts.Include(c => c.Venue).First(c => c.Name == "Cancha 1" && c.Venue != null && c.Venue.Name == "La Fábrica");
        var antartidaCentral = context.Courts.Include(c => c.Venue).First(c => c.Name == "Central" && c.Venue != null && c.Venue.Name == "Antártida Padel");

        var matches = new Match[]
        {
            // Past Matches (Ready)
            new Match { CourtId = laFabricaC1.Id, Status = MatchStatus.Ready, StartTime = DateTime.UtcNow.AddDays(-2), GlobalId = Guid.NewGuid().ToString(), CdnUrl = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" }, // Sample HLS
            new Match { CourtId = laFabricaC1.Id, Status = MatchStatus.Ready, StartTime = DateTime.UtcNow.AddDays(-1), GlobalId = Guid.NewGuid().ToString(), CdnUrl = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" },
            new Match { CourtId = antartidaCentral.Id, Status = MatchStatus.Ready, StartTime = DateTime.UtcNow.AddDays(-3), GlobalId = Guid.NewGuid().ToString(), CdnUrl = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" },
            new Match { CourtId = antartidaCentral.Id, Status = MatchStatus.Ready, StartTime = DateTime.UtcNow.AddDays(-2), GlobalId = Guid.NewGuid().ToString(), CdnUrl = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" },
            new Match { CourtId = antartidaCentral.Id, Status = MatchStatus.Ready, StartTime = DateTime.UtcNow.AddDays(-1), GlobalId = Guid.NewGuid().ToString(), CdnUrl = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8" },

            // Future Matches (Scheduled)
            new Match { CourtId = laFabricaC1.Id, Status = MatchStatus.Scheduled, StartTime = DateTime.UtcNow.AddHours(2), GlobalId = Guid.NewGuid().ToString() },
            new Match { CourtId = antartidaCentral.Id, Status = MatchStatus.Scheduled, StartTime = DateTime.UtcNow.AddHours(5), GlobalId = Guid.NewGuid().ToString() }
        };

        context.Matches.AddRange(matches);
        context.SaveChanges();
    }
}
