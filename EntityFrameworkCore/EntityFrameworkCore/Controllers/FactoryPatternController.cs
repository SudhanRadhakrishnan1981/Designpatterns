using EFModellayer.Data;
using EntityFrameworkCore.FactoryPattern;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactoryPatternController : ControllerBase
    {

        private readonly CustomerPizzaContext context;

        private  IGet _get;

        private readonly ILogger<FactoryPatternController> _logger;

        public FactoryPatternController(ILogger<FactoryPatternController> logger, CustomerPizzaContext customerPizzaContext, IGet get)
        {
            _logger = logger;
            context = customerPizzaContext;
            _get = get;
        }


        // PUT: api/example/5
        [HttpGet(Name = "Factory_Pattern")]
        public IActionResult Getfactory(int value)
        {
            _get = clsFactory.CreateandReturnObj(value);
            string res = _get.ConC("First", "Second");
            return Ok(res);

        }
    }
}
