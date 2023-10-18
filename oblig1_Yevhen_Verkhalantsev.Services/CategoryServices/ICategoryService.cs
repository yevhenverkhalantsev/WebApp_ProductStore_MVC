using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;

public interface ICategoryService
{
    Task<ResponseService> Create(CreateCategoryHttpPostModel createProducerHttpPostModel);

    ICollection<CategoryEntity> GetAll();

}