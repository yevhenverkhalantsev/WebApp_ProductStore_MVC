using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using oblig1_Yevhen_Verkhalantsev.Models.Product;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProductServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Controllers;

public class ProductController: Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IProducerService _producerService;

    public ProductController(IProductService productService,
                            ICategoryService categoryService,
                            IProducerService producerService)
    {
        _productService = productService;
        _producerService = producerService;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CreateProductHttpGetViewModel vm = new CreateProductHttpGetViewModel()
        {
            Categories = _categoryService.GetAll(),
            Producers = _producerService.GetAll()
        };
        
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductHttpPostModel vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await _productService.Create(vm);
        if (response.IsError)
        {
            return BadRequest(new
            {
                errorMessage = response.ErrorMessage
            });
        }
        
        return Ok(new
        {
            success = true
        });
    }
    
    
    [HttpGet]
    public async Task<IActionResult> ProductsList()
    {
        ProductListHttpGetViewModel vm = new ProductListHttpGetViewModel()
        {
            Products = _productService.GetAll()
        };
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        var response = await _productService.GetById(id);
        if(response.IsError)
        {
            return View(new UpdateProductHttpGetViewModel()
            {
                Categories = _categoryService.GetAll(),
                Producers = _producerService.GetAll(),
                ErrorMessage = response.ErrorMessage,
                IsError = true
            });
        }

        return View(new UpdateProductHttpGetViewModel()
        {
            Categories = _categoryService.GetAll(),
            Producers = _producerService.GetAll(),
            IsError = false,
            Product = response.Value
        });

    }
    
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateProductHttpPostModel vm)
    {
        var response = await _productService.Update(vm);
        if (response.IsError)
        {
            return BadRequest(new
            {
                responseMessage = response.ErrorMessage
            });
        }

        return Ok(new
        {
            success = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteProductHttpPostModel vm)
    {
        var response = await _productService.Delete(vm);
        if (response.IsError)
        {
            return BadRequest(new
            {
                responseMessage = response.ErrorMessage
            });
        }

        return Ok(new
        {
            success = true
        });
    }
}

