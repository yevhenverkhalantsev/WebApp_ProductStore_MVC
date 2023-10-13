using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.EntityFramework.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products").HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);
        builder.Property(x => x.Price).IsRequired();

        builder.HasOne<ProducerEntity>(x => x.Producer)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProducerFK);

        builder.HasOne<CategoryEntity>(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryFK);
    }
    
    
}