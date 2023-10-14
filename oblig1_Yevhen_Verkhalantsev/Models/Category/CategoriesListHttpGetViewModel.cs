using oblig1_Yevhen_Verkhalantsev.Database.Entities;

namespace oblig1_Yevhen_Verkhalantsev.Models.Category;

public class CategoriesListHttpGetViewModel
{
    public CategoriesListHttpGetViewModel()
    {
        Categories = new List<CategoryEntity>();
    }
   
    public ICollection<CategoryEntity> Categories { get; set; }
}