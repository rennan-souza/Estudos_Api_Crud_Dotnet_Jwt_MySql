namespace MeuProjeto.Services.IServices
{
    public interface IBcryptService
    {
        bool VerifyMatchPassword(string password, string passwordHash);

        public string GenerateHashPassword(string password);
    }
}
