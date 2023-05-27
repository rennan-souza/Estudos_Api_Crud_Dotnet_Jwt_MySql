using MeuProjeto.Models;

namespace MeuProjeto.Dtos
{
    public class UserLoginRes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Role> Roles { get; set; }

        public string Token { get; set; }
    }
}
