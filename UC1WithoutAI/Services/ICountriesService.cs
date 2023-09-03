using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public interface ICountriesService
    {
        Task<List<Country>> GetCountries();
        Task<IEnumerable<Country>> GetCountriesFilteredByName(string countryName);
        Task<IEnumerable<Country>> GetCountriesLimitedByPopulationInMillions(short limit);
        Task<IEnumerable<Country>> GetCountriesOrderedByName(string orderDirection);
        Task<IEnumerable<Country>> GetCountriesWithPagination(int page, int itemsPerPage);

    }
}
