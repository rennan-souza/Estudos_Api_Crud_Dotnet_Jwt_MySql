using MeuProjeto.Models;

namespace MeuProjeto.Services.IServices
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
