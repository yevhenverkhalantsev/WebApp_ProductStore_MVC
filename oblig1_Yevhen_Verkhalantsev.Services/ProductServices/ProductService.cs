using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Services.ProductServices;

public class ProductService: IProductService

{
    private readonly IGenericRepository<ProductEntity> _productRepository;

    public ProductService(IGenericRepository<ProductEntity> repository)
    {
        _productRepository = repository;
    }

    public async Task<ResponseService> Create(CreateProductHttpPostModel vm)
    {
        ProductEntity productEntity = new ProductEntity()
        {
            Name = vm.Name,
            Description = vm.Description,
            Price = vm.Price,
            CategoryFK = vm.CategoryId,
            ProducerFK = vm.ProducerId
        };

        try
        {
            await _productRepository.Create(productEntity);
        }
        catch (Exception e)
        {
            return ResponseService.Error(e.Message);
        }

        return ResponseService.Ok();
        
    }

    public async Task<ICollection<ProductEntity>> GetAll()
    {
        return await _productRepository.GetAll()
            .Include(x=>x.Producer)
            .Include(x=>x.Category)
            .ToListAsync();
    }
}