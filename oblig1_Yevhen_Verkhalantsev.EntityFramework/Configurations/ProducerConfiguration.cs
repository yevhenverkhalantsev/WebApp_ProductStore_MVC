using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.EntityFramework.Configurations;

public class ProducerConfiguration: IEntityTypeConfiguration<ProducerEntity>
{
    public void Configure(EntityTypeBuilder<ProducerEntity> builder)
    {
        builder.ToTable("Producers").HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Adress).HasMaxLength(500).IsRequired();
    }
}