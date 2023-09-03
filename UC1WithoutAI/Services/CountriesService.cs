using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public class CountriesService : ICountriesService
    {
        private IDataProviderService _providerService;
        private int _limitMultiplier = 1000000;

        public CountriesService(IDataProviderService providerService)
        {

            _providerService = providerService;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _providerService.GetData();
        }

        public async Task<IEnumerable<Country>> GetCountriesFilteredByName(string countryName)
        {
            var res = await _providerService.GetData();
            var lowerCaseSearch = countryName.ToLower();
            return res.Where(i => !string.IsNullOrEmpty(i.Name.Common) && i.Name.Common.ToLower().Contains(lowerCaseSearch));
        }

        public async Task<IEnumerable<Country>> GetCountriesLimitedByPopulationInMillions(short limit)
        {
            var res = await _providerService.GetData();
            var limitInMillions = limit * _limitMultiplier;
            return res.Where(i => i.Population.HasValue && i.Population.Value < limitInMillions);
        }
    }
}
