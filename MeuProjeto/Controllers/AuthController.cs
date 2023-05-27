using MeuProjeto.Dtos;
using MeuProjeto.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public ActionResult<UserLoginRes> Login([FromBody] UserLoginReq dto)
        {
            try
            {
                UserLoginRes userLogged = _authService.Login(dto);
                return Ok(userLogged);
            } catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
