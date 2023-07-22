using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SupportPageApi.Models;
using SupportPageApi.Services;

namespace SupportPageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly AuthenticateService _authenticateService;
        private readonly TokenService _tokenService;
        public LoginController(AuthenticateService authenticateService, TokenService tokenService)
        {
            _authenticateService = authenticateService;
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User usuario)
        {
            if (usuario.Password is null || usuario.Username is null)
            {
                return NotFound("Ingrese un usuario");
            }

            var userNameLogin = usuario.Username.ToUpper();
            var userPasswordLogin = usuario.Password;
            User usuarioLogin = await _authenticateService.ValidateUser(userNameLogin);

            if(usuarioLogin == null)
            {
                return BadRequest("Credenciales incorrectas");
            }

            var passwordIsValidate = _authenticateService.ValidatePassword(usuarioLogin, userPasswordLogin);

            if (passwordIsValidate == "Success")
            {
                var token = _tokenService.GenerateToken(usuario);
                return Ok(token);
            }
            else
            {
                return BadRequest("Credenciales incorrectas");
            }

        }
    }
}
