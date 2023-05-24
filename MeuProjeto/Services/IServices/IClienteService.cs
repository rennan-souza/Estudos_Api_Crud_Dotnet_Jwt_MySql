using MeuProjeto.Dtos;
using MeuProjeto.Models;

namespace MeuProjeto.Services.IServices
{
    public interface IClienteService
    {
        List<Cliente> List();

        Cliente Cadastrar(ClienteReq clienteReq);
    }
}
