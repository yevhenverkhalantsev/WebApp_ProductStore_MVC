using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;

public class CategoryService: ICategoryService

{
    private readonly IGenericRepository<CategoryEntity> _categoryRepository;

    public CategoryService(IGenericRepository<CategoryEntity> repository)
    {
        _categoryRepository = repository;
    }

    public async Task<ResponseService> Create(CreateCategoryHttpPostModel createCategoryHttpPostModel)
    {
        CategoryEntity dbRecord = new CategoryEntity()
        {
            Name = createCategoryHttpPostModel.Name,
            Description = createCategoryHttpPostModel.Description
        };

        try
        {
            await _categoryRepository.Create(dbRecord);
        }
        catch (Exception ex)
        {
            return ResponseService.Error(ex.Message);
        }

        return ResponseService.Ok();
    }

    public async Task<ICollection<CategoryEntity>> GetAll()
    {
        return await _categoryRepository.GetAll().ToListAsync();
    }
}