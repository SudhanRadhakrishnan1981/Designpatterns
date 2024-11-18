using EFModellayer.Models;
using EFServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productcontext;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService customerPizzaContext)
        {
            _logger = logger;
            productcontext = customerPizzaContext;
        }



        //// GET: api/example
        //[HttpGet(Name = "GetProduct")]
        //public ActionResult<IEnumerable<Product>> GetAll()
        //{


        //    var products = productcontext.Product
        //            .Where(p => p.Price > 0.0M)
        //            .OrderBy(p => p.Name)
        //            .AsNoTracking() // Using AsNoTracking to avoid tracking changes
        //            .ToList();


        //    // Replace with logic to fetch and return all items
        //    return Ok(products);
        //}



        // POST: api/example
        [HttpPost(Name = "AddCustomer")]
        public ActionResult Create([FromBody] string value)
        {
           
          
                Product firstproduct = new Product()
                {
                    Name = value,
                    Price = 9.99M
                };
            productcontext.AddProduct(firstproduct);
          
            // Replace with logic to create a new item
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
