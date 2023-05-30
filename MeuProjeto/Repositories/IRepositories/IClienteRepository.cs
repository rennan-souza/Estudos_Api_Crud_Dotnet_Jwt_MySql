using MeuProjeto.Dtos;
using MeuProjeto.Models;

namespace MeuProjeto.Repositories.IRepositories
{
    public interface IClienteRepository
    {
        List<Cliente> List();
        Cliente Cadastrar(ClienteReq clienteReq);
        bool ExisteCpf(string cpf);
        Cliente BuscarPorId(int id);
        Cliente Update(int id, ClienteReq clienteReq);
        void Delete(int id);
    }
}
