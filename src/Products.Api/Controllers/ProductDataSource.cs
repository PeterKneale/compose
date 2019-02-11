using System.Collections.Generic;
using Dapper;

namespace Products.Api.Controllers
{
    public class ProductDataSource : IProductDataSource
    {
        private readonly IConnectionFactory _factory;

        public ProductDataSource(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<ProductData> List()
        {
            return _factory
                .Get()
                .Query<ProductData>("SELECT * FROM [Products]");
        }
    }
}
