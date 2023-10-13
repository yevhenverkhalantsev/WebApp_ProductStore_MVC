using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;

namespace oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;

public class CategoryService: ICategoryService

{
    private readonly IGenericRepository<CategoryEntity> _categoryRepository;
    
    public CategoryService(IGenericRepository<CategoryEntity> repository)
    {
        _categoryRepository = repository;
    }
}