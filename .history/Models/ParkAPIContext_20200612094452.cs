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
        new Park { ParkId = 2, Name = "Marymoor Park", Location = "Redmond", Type = "King County Park", Playground = true, Beach = false, PicnicArea = true, RealBathrooms = true, VisitorCenter = false },
        new Park { ParkId = 3, Name = "Pine Lake Park", Location = "Sammamish/Issaquah", Type = "City Park", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false },
        new Park { ParkId = 4, Name = "Mount Rainier National Park", Location = "Multiple Entrances", Type = "National Park", EntranceFee = 30, Playground = false, Beach = false, PicnicArea = true, RealBathrooms = true, VisitorCenter = true }
      );
    }
  }
}