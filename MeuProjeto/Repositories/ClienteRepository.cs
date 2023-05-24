using Dapper;
using MeuProjeto.Connections;
using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;

namespace MeuProjeto.Repositories
{
    public class ClienteRepository : ConnectionMySql, IClienteRepository
    {
        public List<Cliente> List()
        {
            string sql = "SELECT * FROM TB_CLIENTE";
            return Connection.Query<Cliente>(sql).ToList();
        }
    }
}
