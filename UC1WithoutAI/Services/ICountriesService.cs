using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public interface ICountriesService
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
