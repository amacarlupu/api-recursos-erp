using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupportPageApi.Models;
using SupportPageApi.Services;

namespace SupportPageApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductLinesController: ControllerBase
    {
        private readonly ProductLinesService _productsService;

        // Inserción de dependiencias
        public ProductLinesController(ProductLinesService productsService)
        {
            _productsService = productsService;
        }

        [EnableCors("PolicyNow")]
        [HttpGet]
        public async Task<List<ProductLines>> Get() =>
       await _productsService.GetAsync();

        [EnableCors("PolicyNow")]
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<ProductLines>> Get(string id)
        {
            var resource = await _productsService.GetAsync(id);

            if (resource is null)
            {
                return NotFound();
            }

            return resource;
        }
    }
}
