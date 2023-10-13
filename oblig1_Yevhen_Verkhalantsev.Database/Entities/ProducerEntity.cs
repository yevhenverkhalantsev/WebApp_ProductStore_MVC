namespace oblig1_Yevhen_Verkhalantsev.Database.Entities;

public class ProducerEntity
{
    public ProducerEntity()
    {
        Products = new List<ProductEntity>();
    }
    
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Adress { get; set; } = String.Empty;
    
    public ICollection<ProductEntity> Products { get; set; }
}