using System.Collections.Generic;

namespace Products.Api.Controllers
{
    public interface IProductDataSource
    {
        IEnumerable<ProductData> List();
    }
}