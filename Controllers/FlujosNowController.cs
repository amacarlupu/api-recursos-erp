using SupportPageApi.Models;
using SupportPageApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace SupportPageApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FlujosNowController : ControllerBase
{
    private readonly FlujosNowService _flujosnowService;

    public FlujosNowController(FlujosNowService flujosnowService) =>
        _flujosnowService = flujosnowService;

    [EnableCors("PoliciyNow")]
    [HttpGet]
    [Authorize]
    public async Task<List<FlujosNow>> Get() =>
        await _flujosnowService.GetAsync();

    [EnableCors("PoliciyNow")]
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
