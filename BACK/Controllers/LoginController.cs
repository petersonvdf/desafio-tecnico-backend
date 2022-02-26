using BACK.Models;
using BACK.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BACK.Controllers
{
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(
            [FromBody] User model,
            [FromServices] ITokenService tokenService,
            [FromServices] IUserRepository userRepository)
        {
            var user = await userRepository.Get(model.Login, model.Senha);

            if (user == null)
                return NotFound(new { message = "Login ou senha inválidos" });

            var token = tokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }
    }
}