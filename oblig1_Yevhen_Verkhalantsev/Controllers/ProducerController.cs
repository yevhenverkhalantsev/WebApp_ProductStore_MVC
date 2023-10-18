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
            Producers = _producerService.GetAll()
        };
        return View(vm);
    }

    [HttpGet]
    public async Task<IActionResult> Update(long id)
    {
        var response = await _producerService.GetById(id);
        if (response.IsError)
        {
            return View(new UpdateProducerHttpGetViewModel()
            {
                ErrorMessage = response.ErrorMessage,
                IsError = true
            });
        }
        return View(new UpdateProducerHttpGetViewModel()
        {
            IsError = false,
            Producer = response.Value
        });
        
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateProducerHttpPostModel vm)
    {
        var response = await _producerService.Update(vm);
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