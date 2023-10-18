using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Product;

public class UpdateProductHttpGetViewModel
{
    public UpdateProductHttpGetViewModel()
    {
        Categories = new List<CategoryEntity>();
        Producers = new List<ProducerEntity>();
    }
    
    public ICollection<CategoryEntity> Categories { get; set; }
    public ICollection<ProducerEntity> Producers { get; set; }
    
    public ProductEntity Product { get; set; }
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }
}