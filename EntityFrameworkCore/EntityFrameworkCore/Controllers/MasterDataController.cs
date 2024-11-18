using EFModellayer.Data;
using EntityFrameworkCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDataController : ControllerBase
    {
        private readonly MasterDataService _masterDataService;

        private readonly CustomerPizzaContext context;

        private readonly ILogger<MasterDataController> _logger;

        // Inject the singleton MasterDataService
        public MasterDataController(ILogger<MasterDataController> logger, CustomerPizzaContext customerPizzaContext)
        {

        }

        // Endpoint to get countries
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            //  MasterDataService obj =    new MasterDataService();
            var inst = MasterDataService.Instance;
            var con = inst.Countries;

            return Ok(con);
        }

        // Endpoint to get currencies
        [HttpGet("currencies")]
        public IActionResult GetCurrencies()
        {
            return Ok(_masterDataService.Currencies);
        }
    }
}
