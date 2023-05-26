using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;
using MeuProjeto.Services.IServices;

namespace MeuProjeto.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User BuscarUsuarioPorEmail(string email)
        {

            return userRepository.BuscarUsuarioPorEmail(email);

        }
    }
}
