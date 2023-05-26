using MeuProjeto.Services.IServices;

namespace MeuProjeto.Services
{
    public class BcryptService : IBcryptService
    {
        public string GenerateHashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyMatchPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
