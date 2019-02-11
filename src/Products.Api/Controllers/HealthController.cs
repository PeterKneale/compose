using Microsoft.AspNetCore.Mvc;

namespace Products.Api.Controllers
{
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IProductDataSource _products;

        public HealthController(IProductDataSource products)
        {
            _products = products;
        }

        [Route("api/alive")]
        [HttpGet]
        public OkResult Alive()
        {
            return Ok();
        }

        [Route("api/ready")]
        [HttpGet]
        public OkResult Ready()
        {
            return Ok();
        }
    }
}
