using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {


        public CountriesController()
        {
        }

        [HttpGet(Name = "GetCountries")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}