using Microsoft.EntityFrameworkCore;

namespace ParkAPI.Models
{
  public class ParkAPIContext : DbContext
  {
    public ParkAPIContext(DbContextOptions<ParkAPIContext> options)
        : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
      .HasData(
        new Park { ParkId = 1, Name = "Lake Sammamish State Park", Location = "Issaquah", Type = "Washington State Park", ParkingPermit = "Discover Pass", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false },
        new Park { ParkId = 1, Name = "Lake Sammamish State Park", Location = "Issaquah", Type = "Washington State Park", ParkingPermit = "Discover Pass", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false },
        new Park { ParkId = 1, Name = "Lake Sammamish State Park", Location = "Issaquah", Type = "Washington State Park", ParkingPermit = "Discover Pass", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false },
        new Park { ParkId = 1, Name = "Lake Sammamish State Park", Location = "Issaquah", Type = "Washington State Park", ParkingPermit = "Discover Pass", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false }
      );
    }
  }
}