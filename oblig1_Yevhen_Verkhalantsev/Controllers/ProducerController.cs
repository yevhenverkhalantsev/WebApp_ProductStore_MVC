using Microsoft.AspNetCore.Mvc;
using oblig1_Yevhen_Verkhalantsev.Models.Producer;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices.Models;
using oblig1_Yevhen_Verkhalantsev.Services.Response;

namespace oblig1_Yevhen_Verkhalantsev.Controllers;

public class ProducerController: Controller
{
    private readonly IProducerService _producerService;

    public ProducerController(IProducerService producerService)
    {
        _producerService = producerService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProducerHttpPostModel vm)
    {
        ResponseService response = await _producerService.Create(vm);
        if (response.IsError)
        {
            return BadRequest(new { errorMessage = response.ErrorMessage });
        }
        return Ok(new { success = true });
    }
    
    [HttpGet]
    public async Task<IActionResult> ProducersList()
    {
        ProducersListHttpGetViewModel vm = new ProducersListHttpGetViewModel()
        {
            Producers = await _producerService.GetAll()
        };
        return View(vm);
    }
    
}