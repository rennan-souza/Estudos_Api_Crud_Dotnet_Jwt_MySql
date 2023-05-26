using MeuProjeto.Models;

namespace MeuProjeto.Services.IServices
{
    public interface IUserService
    {
        User BuscarUsuarioPorEmail(string email);
    }
}
