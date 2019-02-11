using Polly;
using System;
using System.Data.SqlClient;
using System.Net.Http;

namespace Products.Api.Controllers
{
    public class Waiter
    {
        public static void WaitDb(string connection)
        {
            var retry = Policy
                .Handle<Exception>()
                .WaitAndRetry(10, x => TimeSpan.FromSeconds(10));
            
            retry.Execute(() =>
            {
                using (var conn = new SqlConnection(connection))
                using (var cmd = new SqlCommand($"SELECT @@VERSION;", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            });
        }

        public static void WaitApi(string uri)
        {
            var retry = Policy
                .Handle<Exception>()
                .WaitAndRetry(10, x => TimeSpan.FromSeconds(10));

            retry.Execute(() =>
            {
                using (var client = new HttpClient())
                {
                    client.GetAsync(uri).Result.EnsureSuccessStatusCode();
                }
            });
        }
    }
}
