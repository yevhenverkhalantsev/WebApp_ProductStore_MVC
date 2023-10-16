using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Product;

public class CreateProductHttpGetViewModel
{
    public CreateProductHttpGetViewModel()
    {
        Producers = new List<ProducerEntity>();
        Categories = new List<CategoryEntity>();
    }
    
    public ICollection<ProducerEntity> Producers { get; set; }
    public ICollection<CategoryEntity> Categories { get; set; }
}