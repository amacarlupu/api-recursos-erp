using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SupportPageApi.Models;
using SupportPageApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private readonly AuthenticateService _authenticateService;
        private readonly TokenService _tokenService;

        public Authenticate(AuthenticateService authenticateService, TokenService tokenService)
        {
            _authenticateService = authenticateService;
            _tokenService = tokenService;
        }


        // GET: api/<Authenticate>
        [EnableCors("PoliciyNow")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Authenticate>/5
        [EnableCors("PoliciyNow")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [EnableCors("PoliciyNow")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User usuario)
        {
            if (usuario.Password is null || usuario.Username is null)
            {
                return NotFound("Por favor complete todos los datos");
            }

            var userNameValidate = usuario.Username.ToUpper();
            User userExist = await _authenticateService.ValidateUser(userNameValidate);

            if (userExist == null)
            {
                Console.WriteLine(usuario);
                Console.WriteLine(usuario.Password);
                usuario.Password = _authenticateService.GenerateHash(usuario);
                usuario.Username = userNameValidate;
                var token = _tokenService.GenerateToken(usuario);
                await _authenticateService.CreateAsync(usuario);

                return Ok(token);
            }
            else
            {
                return BadRequest("Usuario ya existe");
            }
            
        }

        // PUT api/<Authenticate>/5
        [EnableCors("PoliciyNow")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Authenticate>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
