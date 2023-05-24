﻿using MeuProjeto.Dtos;
using MeuProjeto.Models;

namespace MeuProjeto.Repositories.IRepositories
{
    public interface IClienteRepository
    {
        List<Cliente> List();
        Cliente Cadastrar(ClienteReq clienteReq);
        bool ExisteCpf(string cpf);
    }
}