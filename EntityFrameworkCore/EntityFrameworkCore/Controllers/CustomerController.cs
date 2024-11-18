using EFModellayer.Data;
using EFModellayer.Models;
using EntityFrameworkCore.Luhncheckdigit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerPizzaContext context;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, CustomerPizzaContext customerPizzaContext)
        {
            _logger = logger;
            context = customerPizzaContext;
        }



        // GET: api/example
        [HttpGet(Name = "GetCustomer")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
                var Customers = context.Customer
                                .Include(c => c.Orders)
                                .AsNoTracking()
                                .ToList();

            bool test = Luhn("6331101999990016");

            // Example usage:
            var str = "1234567897";

            var isValid = LuhnAlgorithm.ValidateCheckDigit(str);

            // Replace with logic to fetch and return all items
            return Ok(Customers);
        }

        private bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }



        //// POST: api/example
        //[HttpPost(Name = "AddCustomer")]
        //public ActionResult Create([FromBody] string value)
        //{


        //        Product firstproduct = new Product()
        //        {
        //            Name = "Savi Chicken Pizza",
        //            Price = 9.99M
        //        };
        //        context.Product.Add(firstproduct);

        //        Product firstproduct1 = new Product()
        //        {
        //            Name = "Athulya Chicken Pizza",
        //            Price = 12.99M
        //        };
        //        context.Add(firstproduct1);

        //        context.SaveChanges();


        //    // Replace with logic to create a new item
        //    return Ok();
        //}



        //// DELETE: api/example/5
        //[HttpDelete("{Productname}")]
        //public IActionResult Delete(string Productname)
        //{


        //    var Aswathproducts = context.Product
        //            .Where(p => p.Name == Productname)
        //            .FirstOrDefault();

        //    if (Aswathproducts is Product)
        //    {
        //        context.Remove(Aswathproducts);
        //    }
        //    context.SaveChanges();

        //    return Ok();
        //}
    }
}
