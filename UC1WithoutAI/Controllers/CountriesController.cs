using Microsoft.AspNetCore.Mvc;
using UCWithoutAi.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountriesController : ControllerBase
    {
        private ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        [ActionName("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _countriesService.GetCountries());
        }

        [HttpGet]
        [ActionName("GetCountriesFilteredByName")]
        public async Task<IActionResult> GetCountriesFilteredByName(string search)
        {
            return Ok(await _countriesService.GetCountriesFilteredByName(search));
        }

        [HttpGet]
        [ActionName("GetCountriesLimitedByPopulationInMillions")]
        public async Task<IActionResult> GetCountriesLimitedByPopulationInMillions(short limit)
        {
            return Ok(await _countriesService.GetCountriesLimitedByPopulationInMillions(limit));
        }

        [HttpGet]
        [ActionName("GetCountriesOrderedByName")]
        public async Task<IActionResult> GetCountriesOrderedByName(string orderDirection)
        {
            return Ok(await _countriesService.GetCountriesOrderedByName(orderDirection));
        }


        [HttpGet]
        [ActionName("GetCountriesByItems")]
        public async Task<IActionResult> GetNThCountry(int page, int itemsPerPage)
        {
            return Ok(await _countriesService.GetCountriesWithPagination(page, itemsPerPage));
        }

        [HttpGet]
        [ActionName("GetCountriesFiltered")]
        public async Task<IActionResult> GetCountriesFiltered(string? search, short? limit, string? orderDirection, int? page, int? itemsPerPage)
        {
            return Ok(await _countriesService.GetCountriesFiltered(search, limit, orderDirection, page, itemsPerPage));
        }
    }
}
