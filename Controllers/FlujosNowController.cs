using SupportPageApi.Models;
using SupportPageApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SupportPageApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FlujosNowController : ControllerBase
{
    private readonly FlujosNowService _flujosnowService;

    public FlujosNowController(FlujosNowService flujosnowService) =>
        _flujosnowService = flujosnowService;

    [HttpGet]
    [Authorize]
    public async Task<List<FlujosNow>> Get() =>
        await _flujosnowService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<FlujosNow>> Get(string id)
    {
        var resource = await _flujosnowService.GetAsync(id);

        if (resource is null)
        {
            return NotFound();
        }

        return resource;
    }
}
