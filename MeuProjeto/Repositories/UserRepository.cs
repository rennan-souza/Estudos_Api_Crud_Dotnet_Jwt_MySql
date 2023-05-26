using Dapper;
using MeuProjeto.Connections;
using MeuProjeto.Models;
using MeuProjeto.Repositories.IRepositories;

namespace MeuProjeto.Repositories
{
    public class UserRepository : ConnectionMySql, IUserRepository
    {
        public User BuscarUsuarioPorEmail(string email)
        {
            string userSql = $"SELECT * FROM TB_USERS WHERE EMAIL = '{email}'";
            var user = Connection.Query<User>(userSql).First();


            string rolesSql = $"SELECT ID, AUTHORITY FROM TB_ROLES JOIN TB_USERS_ROLES ON TB_USERS_ROLES.ROLE_ID = TB_ROLES.ID WHERE USER_ID = {user.Id}";
            var roles = Connection.Query<Role>(rolesSql).ToList();

            return new User { Id = user.Id, Name = user.Name, Email = email, Password = user.Password, Roles = roles };
        }
    }
}
