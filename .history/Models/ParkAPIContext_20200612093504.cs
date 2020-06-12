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
      builder.Entity<Remedy>()
      .HasData(
  }
  }