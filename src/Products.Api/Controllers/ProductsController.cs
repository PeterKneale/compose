using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDataSource _products;

        public ProductsController(IProductDataSource products)
        {
            _products = products;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            var data = _products.List();
            var models = data.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name
            });
            return Ok(models);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
