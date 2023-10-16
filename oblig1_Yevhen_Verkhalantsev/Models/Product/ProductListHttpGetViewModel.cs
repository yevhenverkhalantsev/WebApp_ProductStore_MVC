using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Product;

public class ProductListHttpGetViewModel
{

    public ProductListHttpGetViewModel()
    {
        Products = new List<ProductEntity>();
    }
   
    public ICollection<ProductEntity> Products { get; set; }
}