using Microsoft.EntityFrameworkCore;
using VPCAM.Core.Entities;

namespace VPCAM.Worker.Data;

public class WorkerDbContext : DbContext
{
    public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
    {
    }

    public DbSet<Match> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Match>()
            .Property(m => m.Status)
            .HasConversion<string>();
    }
}
