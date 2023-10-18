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

    public ICollection<ProductEntity> GetAll()
    {
        return _productRepository.GetAll()
            .Include(x=>x.Producer)
            .Include(x=>x.Category)
            .ToList();
    }

    public async Task<ResponseService<ProductEntity>> GetById(long id)
    {
        ProductEntity product = await _productRepository.GetById(id);
        if (product == null)
        {
            return ResponseService<ProductEntity>.Error("No product with that id");
        }

        return ResponseService<ProductEntity>.Ok(product);
    }

    public async Task<ResponseService> Update(UpdateProductHttpPostModel vm)
    {
        ProductEntity productEntity = await _productRepository.GetById(vm.Id);
        if (productEntity == null)
        {
            return ResponseService.Error("Bad products id");
        }

        productEntity.Name = vm.Name;
        productEntity.Description = vm.Description;
        productEntity.Price = vm.Price;
        productEntity.CategoryFK = vm.CategoryId;
        productEntity.ProducerFK = vm.ProducerId;

        try
        {
            await _productRepository.Update(productEntity);
        }
        catch (Exception e)
        {
            return ResponseService.Error(e.Message);
        }

        return ResponseService.Ok();
    }

    public async Task<ResponseService> Delete(DeleteProductHttpPostModel vm)
    {
        ProductEntity product = await _productRepository.GetById(vm.Id);
        if (product == null)
        {
            return ResponseService.Error("Product with that id is not found");
        }

        try
        {
           await _productRepository.Delete(product);

        }
        catch (Exception e)
        {
            return ResponseService.Error(e.Message);
        }

        return ResponseService.Ok();
    }
}