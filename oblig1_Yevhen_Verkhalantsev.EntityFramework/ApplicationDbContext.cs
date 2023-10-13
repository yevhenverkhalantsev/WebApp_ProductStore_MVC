using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Configurations;

namespace oblig1_Yevhen_Verkhalantsev.EntityFramework;

public class ApplicationDbContext: DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        Database.Migrate();
    }
    
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProducerEntity> Producers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProducerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}