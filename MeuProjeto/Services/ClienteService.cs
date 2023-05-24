using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;
using MeuProjeto.Services.IServices;

namespace MeuProjeto.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public List<Cliente> List()
        {
            try
            {
                return clienteRepository.List();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
