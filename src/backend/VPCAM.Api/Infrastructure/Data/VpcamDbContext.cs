using Microsoft.EntityFrameworkCore;
using VPCAM.Core.Entities;

namespace VPCAM.Api.Infrastructure.Data;

public class VpcamDbContext : DbContext
{
    public VpcamDbContext(DbContextOptions<VpcamDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Court> Courts { get; set; }
    public DbSet<Match> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.ExternalIdentityId)
            .IsUnique();

        modelBuilder.Entity<Match>()
            .Property(m => m.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Venue>()
            .HasMany(v => v.Courts)
            .WithOne(c => c.Venue)
            .HasForeignKey(c => c.VenueId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Court>()
            .HasMany<Match>()
            .WithOne(m => m.Court)
            .HasForeignKey(m => m.CourtId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
