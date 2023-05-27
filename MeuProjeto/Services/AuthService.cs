using MeuProjeto.Dtos;
using MeuProjeto.Services.IServices;

namespace MeuProjeto.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService userService;
        private readonly IJwtTokenService jwtTokenService;
        private readonly IBcryptService bcryptService;

        public AuthService(IUserService userService, IJwtTokenService jwtTokenService, IBcryptService bcryptService)
        {
            this.userService = userService;
            this.jwtTokenService = jwtTokenService;
            this.bcryptService = bcryptService;
        }   

        public UserLoginRes Login(UserLoginReq dto)
        {
            var user = userService.BuscarUsuarioPorEmail(dto.Email);

            if (user == null)
            {
                throw new Exception("Usuário ou senha inválidos");
            }

            if (!bcryptService.VerifyMatchPassword(dto.Password, user.Password))
            {
                throw new Exception("Usuário ou senha inválidos");
            }

            var token = jwtTokenService.GenerateToken(user);

            user.Password = "";
            return new UserLoginRes
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Roles = user.Roles,
                Token = token,
            };
        }
    }
}
