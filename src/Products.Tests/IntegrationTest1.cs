using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Products.Api.Controllers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Products.Tests
{
    public class IntegrationTest1
    {
        private const string Api = "http://products.api/api";
        private const string Db = "Server=products.db;Database=Products;User Id=sa;Password=Pass@word";

        public IntegrationTest1()
        {
            Waiter.WaitDb(Db);
            Waiter.WaitApi($"{Api}/alive");
            Waiter.WaitApi($"{Api}/ready");
        }

        [Fact]
        public async Task TestConnectiivty()
        {
            using (var client = new HttpClient())
            {
                var productsApi = $"{Api}/products";
                
                var response = await client.GetStringAsync(productsApi);
                var values = JsonConvert.DeserializeObject(response) as JArray;

                Assert.NotNull(values);
            }
        }
    }
}
