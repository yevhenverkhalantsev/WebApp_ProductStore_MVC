namespace oblig1_Yevhen_Verkhalantsev.Database.Entities;

public class ProductEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public float Price { get; set; }
    
    public long CategoryFK { get; set; }
    public CategoryEntity Category { get; set; }
    
    public long ProducerFK { get; set; }
    public ProducerEntity Producer { get; set; }
    
}