using System.Data.SqlClient;

namespace Products.Api.Controllers
{
    public static class ConnectionStringExtensions
    {
        public static string GetMasterConnection(this string connection)
        {
            var builder = new SqlConnectionStringBuilder(connection)
            {
                InitialCatalog = "master"
            };
            return builder.ToString();
        }

        public static string GetDatabaseName(this string connection)
        {
            var builder = new SqlConnectionStringBuilder(connection);
            return builder.InitialCatalog;
        }
    }
}
