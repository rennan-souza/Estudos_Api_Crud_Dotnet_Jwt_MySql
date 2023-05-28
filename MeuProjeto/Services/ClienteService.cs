using MeuProjeto.Dtos;
using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;
using MeuProjeto.Services.IServices;
using System.Text.RegularExpressions;

namespace MeuProjeto.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Cliente Cadastrar(ClienteReq clienteReq)
        {
            try
            {
                clienteReq.Cpf = FormatarCPF(clienteReq.Cpf);

                if (clienteRepository.ExisteCpf(clienteReq.Cpf))
                {
                    throw new Exception("O CPF informado já está cadastrado");
                }

               
                return clienteRepository.Cadastrar(clienteReq);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public Cliente BuscarPorId(int id)
        {
            return clienteRepository.BuscarPorId(id);
        }

        public static string FormatarCPF(string cpf)
        {
            // Remove todos os caracteres não numéricos do CPF
            string cpfNumerico = Regex.Replace(cpf, "[^0-9]", "");

            // Verifica se o CPF possui 11 dígitos
            if (cpfNumerico.Length != 11)
            {
                throw new ArgumentException("O CPF deve conter 11 dígitos.");
            }

            // Aplica a formatação com pontos e traço
            string cpfFormatado = $"{cpfNumerico.Substring(0, 3)}.{cpfNumerico.Substring(3, 3)}.{cpfNumerico.Substring(6, 3)}-{cpfNumerico.Substring(9)}";

            return cpfFormatado;
        }
    }
}
