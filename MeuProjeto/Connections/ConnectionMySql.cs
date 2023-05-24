using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace MeuProjeto.Connections
{
    public class ConnectionMySql : IDisposable
    {
        public IDbConnection Connection { get; }
        private IConfiguration configuration;

        public ConnectionMySql()
        {
            try
            {
                // Carrega o arquivo de configuração
                configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

          
                string DatabaseHost = Environment.GetEnvironmentVariable("DB_HOST") ?? configuration["DatabaseSettings:DB_HOST"];
                string DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? configuration["DatabaseSettings:DATABASE_NAME"];
                string DatabaseUser = Environment.GetEnvironmentVariable("DATABASE_USER") ?? configuration["DatabaseSettings:DATABASE_USER"];
                string DatabasePass = Environment.GetEnvironmentVariable("DATABASE_PASS") ?? configuration["DatabaseSettings:DATABASE_PASS"];

                string connectionString = $"server={DatabaseHost};database={DatabaseName};uid={DatabaseUser};pwd={DatabasePass};";
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
