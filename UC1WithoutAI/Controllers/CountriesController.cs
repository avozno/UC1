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

        [HttpGet(Name = "GetCountriesFilteredByName")]
        public async Task<IActionResult> GetCountriesFilteredByName(string search)
        {
            return Ok(await _countriesService.GetCountriesFilteredByName(search));
        }

        [HttpGet(Name = "GetCountriesLimitedByPopulationInMillions")]
        public async Task<IActionResult> GetCountriesLimitedByPopulationInMillions(short limit)
        {
            return Ok(await _countriesService.GetCountriesLimitedByPopulationInMillions(limit));
        }

        [HttpGet(Name = "GetCountriesSortedByName")]
        public async Task<IActionResult> GetCountriesOrderedByName(string orderDirection)
        {
            return Ok(await _countriesService.GetCountriesOrderedByName(orderDirection));
        }


        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> GetCountries(int page, int itemsPerPage)
        {
            return Ok(await _countriesService.GetCountriesWithPagination(page, itemsPerPage));
        }
    }
}
