using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices;

public interface IProductService
{
    Task<ResponseService> Create(CreateProductHttpPostModel vm);
    Task<ICollection<ProductEntity>> GetAll();
}