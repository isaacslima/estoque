using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Product Get(int IdProduct)
        {
            // TODO get product by id
            var product = new Product{
                Name = "Headset",
                Quantity = 1,
                UnitValue = (decimal)189.90,
            };
            return product;
        }

        [HttpPost]
        public bool Post(Product product)
        {
            // TODO insert new product
            return true;
        }

        [HttpDelete]
        public bool Delete(Product product)
        {
            // Todo delete product
            return true;
        }
    }
}
