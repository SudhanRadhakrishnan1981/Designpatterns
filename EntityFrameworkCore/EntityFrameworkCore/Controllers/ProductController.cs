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

        public ProductController(ILogger<ProductController> logger, IProductService customerPizzaContext, IRabitMQProducer rabitMQProducer)
        {
            _logger = logger;
            productservices = customerPizzaContext;
            _rabitMQProducer = rabitMQProducer;
        }



        // GET: api/example
        [HttpGet(Name = "GetProduct")]
        public async Task<IActionResult> GetAll()
        {


            //var products = productcontext.Product
            //        .Where(p => p.Price > 0.0M)
            //        .OrderBy(p => p.Name)
            //        .AsNoTracking() // Using AsNoTracking to avoid tracking changes
            //        .ToList();

          //  var products = productservices.GetProductList();
            var products = await productservices.GetAllProductsAsync();


            // Replace with logic to fetch and return all items
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
        public IActionResult Delete(string Productname)
        {


            //var Aswathproducts = context.Product
            //        .Where(p => p.Name == Productname)
            //        .FirstOrDefault();

            //if (Aswathproducts is Product)
            //{
            //    context.Remove(Aswathproducts);
            //}
            //context.SaveChanges();

            return Ok();
        }
    }
}
