using MeuProjeto.Dtos;

namespace MeuProjeto.Services.IServices
{
    public interface IAuthService
    {
        UserLoginRes Login (UserLoginReq dto);
    }
}
