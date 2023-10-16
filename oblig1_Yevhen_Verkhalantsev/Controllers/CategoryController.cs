using Microsoft.AspNetCore.Mvc;
using oblig1_Yevhen_Verkhalantsev.Models.Category;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices;
using oblig1_Yevhen_Verkhalantsev.Services.CategoryServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Controllers;

public class CategoryController: Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryHttpPostModel vm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        ResponseService response = await _categoryService.Create(vm);
        if (response.IsError)
        {
            return BadRequest(new { errorMessage = response.ErrorMessage });
        }
        return Ok(new { success = true });
    }
    
    [HttpGet]
    public async Task<IActionResult> CategoriesList()
    {
        CategoriesListHttpGetViewModel vm = new CategoriesListHttpGetViewModel()
        {
            Categories = await _categoryService.GetAll()
        };
        return View(vm);
    }
    
}