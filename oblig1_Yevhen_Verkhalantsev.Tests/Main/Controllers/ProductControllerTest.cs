using Microsoft.AspNetCore.Mvc;
using oblig1_Yevhen_Verkhalantsev.Controllers;
using oblig1_Yevhen_Verkhalantsev.Database.Entities;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;
using oblig1_Yevhen_Verkhalantsev.Models.Product;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;
using oblig1_Yevhen_Verkhalantsev.Tests.Fakes.FakeRepository;
using Xunit;

namespace oblig1_Yevhen_Verkhalantsev.Tests.Main.Controllers;

public class ProductControllerTest
{
    private readonly ProductController _controller;

    private readonly IGenericRepository<ProductEntity> _productRepository;
    private readonly IGenericRepository<CategoryEntity> _categoryRepository;
    private readonly IGenericRepository<ProducerEntity> _producerRepository;
    
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IProducerService _producerService;
    
    public ProductControllerTest()
    {
        _productRepository = new FakeRepository<ProductEntity>();
        _categoryRepository = new FakeRepository<CategoryEntity>();
        _producerRepository = new FakeRepository<ProducerEntity>();

        _productService = new ProductService(_productRepository);
        _categoryService = new CategoryService(_categoryRepository);
        _producerService = new ProducerService(_producerRepository);

        _controller = new ProductController(_productService, _categoryService, _producerService);
    }
    
    [Fact]
    public async Task CreateReturnsBadRequestIfReceivedEmptyModel()
    {
        //Arrange
        CreateProductHttpPostModel vm = new CreateProductHttpPostModel()
        {
            CategoryId = 0,
            Description = String.Empty,
            Name = String.Empty,
            Price = 0,
            ProducerId = 0
        };
        
        //Act
        var response = await _controller.Create(vm) as ObjectResult;

        //Assert
        Assert.Equal(200, response.StatusCode);

    }

    [Fact]
    public async Task CreateReturnsProducersAndCategoriesNotNull()
    {
        var response = await _controller.Create() as ViewResult;
        var vm = response.Model as CreateProductHttpGetViewModel;
        var categories = vm.Categories;
        var producers = vm.Producers;
        
        Assert.NotNull(categories);
        Assert.NotNull(producers);
    }
    
    [Fact]
    public async Task ProductsListReturnsProductsNotNull()
    {
        var response = await _controller.ProductsList() as ViewResult;
        var vm = response.Model as ProductListHttpGetViewModel;
        var products = vm.Products;
        
        Assert.NotNull(products);
    }
    
    [Fact]
    public async Task UpdateReturnsViewWithError()
    {
        var response = await _controller.Update(1) as ViewResult;
        var vm = response.Model as UpdateProductHttpGetViewModel;
        
        Assert.True(vm.IsError);
    }

    [Fact]
    public async Task UpdateProductSuccessfully()
    {
        var vm = new UpdateProductHttpPostModel()
        {
            Id = 1,
            CategoryId = 1,
            Description = "Test",
            Name = "Test",
            Price = 1,
            ProducerId = 1
        };
        
        var response = await _controller.Update(vm) as ObjectResult;
        
        Assert.Equal(400, response.StatusCode);
    }
    
    [Fact]
    public async Task DeleteProductSuccessfully()
    {
        var vm = new DeleteProductHttpPostModel()
        {
            Id = 1
        };
        
        var response = await _controller.Delete(vm) as ObjectResult;
        
        Assert.Equal(400, response.StatusCode);
    }
}