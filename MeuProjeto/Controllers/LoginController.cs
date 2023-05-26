using MeuProjeto.Dtos;
using MeuProjeto.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IJwtTokenService jwtTokenService;
        private readonly IBcryptService bcryptService;

        public LoginController(IUserService userService, IJwtTokenService jwtTokenService, IBcryptService bcryptService)
        {
            this.userService = userService;
            this.jwtTokenService = jwtTokenService;
            this.bcryptService = bcryptService;
        }

        [HttpPost]
        public async Task<dynamic> Authenticate([FromBody] UserLogin dto)
        {
            try
            {
                var user = userService.BuscarUsuarioPorEmail(dto.Email);
                if (!bcryptService.VerifyMatchPassword(dto.Password, user.Password))
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }

                var token = jwtTokenService.GenerateToken(user);

                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
        }
    }
}
