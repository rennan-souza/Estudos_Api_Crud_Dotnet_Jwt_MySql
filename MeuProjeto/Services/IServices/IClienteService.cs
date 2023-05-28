using MeuProjeto.Dtos;
using MeuProjeto.Models;

namespace MeuProjeto.Services.IServices
{
    public interface IClienteService
    {
        List<Cliente> List();
        Cliente Cadastrar(ClienteReq clienteReq);
        Cliente BuscarPorId(int id);
        Cliente Update(int id, ClienteReq clienteReq);
    }
}
