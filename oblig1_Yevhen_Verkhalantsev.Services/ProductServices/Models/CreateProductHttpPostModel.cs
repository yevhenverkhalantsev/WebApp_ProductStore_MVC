namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;

public class CreateProductHttpPostModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public long ProducerId { get; set; }
    public long CategoryId { get; set; }
    
}