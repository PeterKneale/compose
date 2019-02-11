using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Products.Api.Controllers
{
    public class ConnectionFactory :  IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"] ?? throw new System.Exception("Cannot find ConnectionString");
        }

        public IDbConnection Get() => new SqlConnection(_connectionString);
    }
}