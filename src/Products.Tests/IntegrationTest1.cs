using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Products.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Products.Tests
{
    public class IntegrationTest1
    {
        private const string Api = "http://products.api/api";
        private const string Browser = "http://browser:4444/wd/hub/";

        private static string Alive => $"{Api}/alive";
        private static string Ready => $"{Api}/alive";
        private static string Products => $"{Api}/products";

        private const string Db = "Server=products.db;Database=Products;User Id=sa;Password=Pass@word";

        public IntegrationTest1()
        {
            Waiter.WaitDb(Db);
            Waiter.WaitApi(Alive);
            Waiter.WaitApi(Products);
        }

        [Theory]
        [MemberData(nameof(Urls))]
        public async Task Should_connect_with_http_client(string url)
        {
            using (var client = new HttpClient())
            {
                var productsApi = $"{Api}/products";

                var response = await client.GetStringAsync(productsApi);
                var values = JsonConvert.DeserializeObject(response) as JArray;

                Assert.NotNull(values);
            }
        }

        [Theory]
        [MemberData(nameof(Urls))]
        public void Should_connect_with_browser(string url)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");

            using (var driver = new RemoteWebDriver(new Uri(Browser), options))
            {
                Console.WriteLine($"Going to {url}");
                driver.Navigate().GoToUrl(url);
            }
        }

        public static IEnumerable<object[]> Urls => new List<object[]> {
            new object[] { Alive },
            new object[] { Ready },
            new object[] { Products }
        };
    }
}
