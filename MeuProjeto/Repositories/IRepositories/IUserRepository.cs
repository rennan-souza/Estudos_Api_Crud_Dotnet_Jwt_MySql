using MeuProjeto.Models;

namespace MeuProjeto.Repositories.IRepositories
{
    public interface IUserRepository
    {
        User BuscarUsuarioPorEmail(string email);
    }
}
