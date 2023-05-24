﻿using Dapper;
using MeuProjeto.Connections;
using MeuProjeto.Dtos;
using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;

namespace MeuProjeto.Repositories
{
    public class ClienteRepository : ConnectionMySql, IClienteRepository
    {
        public Cliente Cadastrar(ClienteReq clienteReq)
        {
            string sql = $"INSERT INTO TB_CLIENTE (NOME, CPF) VALUES ('{clienteReq.Nome}', '{clienteReq.Cpf}'); SELECT * FROM TB_CLIENTE WHERE id = LAST_INSERT_ID();";
            return Connection.Query<Cliente>(sql).First();
        }

        public bool ExisteCpf(string cpf)
        {
            string sql = $"SELECT EXISTS(SELECT 1 FROM TB_CLIENTE WHERE CPF = '{cpf}') AS cpf_existe;";
            var verificarCpf = Connection.Query<bool>(sql).FirstOrDefault();
            if (verificarCpf == true)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public List<Cliente> List()
        {
            string sql = "SELECT * FROM TB_CLIENTE";
            return Connection.Query<Cliente>(sql).ToList();
        }


    }
}