using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Country>> GetCountriesFilteredByName(string countryName);
    }
}
