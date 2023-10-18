using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices;

public interface IProductService
{
    Task<ResponseService> Create(CreateProductHttpPostModel vm);
    ICollection<ProductEntity> GetAll();

    Task<ResponseService<ProductEntity>> GetById(long id);
    
    Task<ResponseService> Update(UpdateProductHttpPostModel vm);

    Task<ResponseService> Delete(DeleteProductHttpPostModel vm);
}