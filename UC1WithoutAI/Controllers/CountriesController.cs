using Microsoft.AspNetCore.Mvc;
using UCWithoutAi.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _countriesService.GetCountries());
        }
    }
}