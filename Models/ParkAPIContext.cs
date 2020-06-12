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
        new Park { ParkId = 1, Name = "Lake Sammamish State Park", Location = "Issaquah", Type = "Washington State Park", ParkingPermit = "Discover Pass", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false, UserId = 100 },
        new Park { ParkId = 2, Name = "Marymoor Park", Location = "Redmond", Type = "King County Park", Playground = true, Beach = false, PicnicArea = true, RealBathrooms = true, VisitorCenter = false, UserId = 100 },
        new Park { ParkId = 3, Name = "Pine Lake Park", Location = "Sammamish/Issaquah", Type = "City Park", Playground = true, Beach = true, PicnicArea = true, RealBathrooms = true, VisitorCenter = false, UserId = 100 },
        new Park { ParkId = 4, Name = "Mount Rainier National Park", Location = "Multiple Entrances", Type = "National Park", EntranceFee = 30, Playground = false, Beach = false, PicnicArea = true, RealBathrooms = true, VisitorCenter = true, UserId = 100 }
      );
      builder.Entity<Rating>()
      .HasData(
        new Rating { RatingId = 1, Clean = 4, Accessible = 2, FunForKids = 2, FunForParents = 3, ParkId = 4, UserId = 3, Comments = "Prepare for a lot of time in the car." },
        new Rating { RatingId = 2, Clean = 3, Accessible = 4, FunForKids = 4, FunForParents = 4, ParkId = 3, UserId = 2, Comments = "Relaxing and fun, but the beach can get gross." },
        new Rating { RatingId = 3, Clean = 2, Accessible = 5, FunForKids = 5, FunForParents = 3, ParkId = 1, UserId = 1, Comments = "Lots to do, but also lots of trash and goose poop." }
      );

      builder.Entity<User>()
      .HasData(
        new User { Id = 1, Username = "Pete", Password = "p" },
        new User { Id = 2, Username = "George", Password = "g" },
        new User { Id = 3, Username = "Sam", Password = "s" }
      );

    }
  }
}