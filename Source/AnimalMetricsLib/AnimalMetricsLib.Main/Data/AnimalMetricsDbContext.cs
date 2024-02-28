using AnimalMetricsLib.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalMetricsLib.Data;

public class AnimalMetricsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Animal>? Animals { get; set; }
    public DbSet<NutritionInfo>? NutritionInfos { get; set; }
    public DbSet<FeedType>? FeedTypes { get; set; }
    public DbSet<GrowthRecord>? GrowthRecords { get; set; }
    public DbSet<DietPlan>? DietPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define any model configurations here
        modelBuilder.Entity<Animal>().ToTable("Animals");
  
        modelBuilder.Entity<NutritionInfo>().ToTable("NutritionInfos");
  
        modelBuilder.Entity<FeedType>().ToTable("FeedTypes");
  
        modelBuilder.Entity<GrowthRecord>()
            .ToTable("GrowthRecords")
            .HasOne(g => g.Animal)
            .WithMany()
            .HasForeignKey(g => g.AnimalId);

        modelBuilder.Entity<DietPlan>()
            .ToTable("DietPlans")
            .HasOne(d => d.Animal)
            .WithMany()
            .HasForeignKey(d => d.AnimalId);
    }
}