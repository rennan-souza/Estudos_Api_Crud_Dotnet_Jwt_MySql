﻿using MeuProjeto.Dtos;
using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;
using MeuProjeto.Services.IServices;
using MySqlX.XDevAPI;
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
            Cliente cliente = clienteRepository.BuscarPorId(id);
            if (cliente == null)
            {
                throw new Exception("Nenhum cliente encontrado");
            }
            return cliente;
        }

        public Cliente Update(int id, ClienteReq clienteReq)
        {
            try
            {
                clienteReq.Cpf = FormatarCPF(clienteReq.Cpf);

                Cliente cliente = BuscarPorId(id);

                if (!cliente.Cpf.Equals(clienteReq.Cpf))
                {
                    if (clienteRepository.ExisteCpf(clienteReq.Cpf))
                    {
                        throw new Exception("O CPF informado já está cadastrado");
                    }
                }

                return clienteRepository.Update(id, clienteReq);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public void Delete(int id)
        {
            try
            {
                clienteRepository.Delete(id);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
