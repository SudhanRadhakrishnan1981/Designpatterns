using EFModellayer.Models;
using EFServiceLayer.RabitMQ;
using EFServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productservices;

        private readonly ILogger<ProductController> _logger;

        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductController(ILogger<ProductController> logger, IProductService customerProductService, IRabitMQProducer rabitMQProducer)
        {
            _logger = logger;
            productservices = customerProductService;
            _rabitMQProducer = rabitMQProducer;
        }



        // GET: api/example
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetAll()
        {

            var products = await productservices.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("getproductbyid")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var product = await productservices.GetProductById(Id);
            return Ok(product);
        }

        // POST: api/example
        [HttpPost(Name = "AddCustomer")]
        public ActionResult Create(Product product)
        {
            if (product != null)
            {
                Product firstproduct = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    ProductDescription = product.ProductDescription,
                    ProductStock = product.ProductStock
                };
                productservices.AddProduct(firstproduct);
                _rabitMQProducer.SendProductMessage(firstproduct);
            }
          
            // 
            return Ok();
        }

        // PUT: api/example/5
        [HttpPut("{price}")]
        public IActionResult Update(decimal price, [FromBody] string value)
        {



            //var Aswathproducts = productcontext.Product
            //        .Where(p => p.Name == value)
            //        .FirstOrDefault();

            //if (Aswathproducts is Product)
            //{
            //    Aswathproducts.Price = price;
            //}
            //context.SaveChanges();

            return Ok();

        }

        // DELETE: api/example/5
        [HttpDelete("{Productname}")]
        public async Task<IActionResult> Delete(int ProductId)
        {
            var product = await productservices.GetProductById(ProductId);

            if (product != null)
            {
                productservices.DeleteProduct(product);
            }


            return Ok();
        }
    }
}
