using System.Data.SqlClient;
using Dapper;

namespace Products.Api.Controllers
{
    public class ProductDatabase
    {
        public static void Create(string connection, string name)
        {
            var sqlExists = $"SELECT COUNT(1) FROM SYSDATABASES WHERE NAME='{name}'";
            var sqlCreate = $"CREATE DATABASE {name}";
            using (var conn = new SqlConnection(connection))
            {
                if (conn.ExecuteScalar<bool>(sqlExists))
                {
                    return;
                }
                conn.Execute(sqlCreate);
            }
        }
    }
}
