using Microsoft.AspNetCore.Mvc;
using oblig1_Yevhen_Verkhalantsev.Services.ProducerServices.Models;

namespace oblig1_Yevhen_Verkhalantsev.Controllers;

public class ProducerController: Controller
{
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProducerHttpPostModel vm)
    {
        return Ok();
    }
}