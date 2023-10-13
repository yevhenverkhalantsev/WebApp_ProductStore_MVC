using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices;

public class ProductService: IproductService

{
    private readonly IGenericRepository<ProductEntity> _productRepository;

    public ProductService(IGenericRepository<ProductEntity> repository)
    {
        _productRepository = repository;
    }
}