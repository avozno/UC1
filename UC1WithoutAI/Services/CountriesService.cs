using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public class CountriesService : ICountriesService
    {
        private IDataProviderService _providerService;

        public CountriesService(IDataProviderService providerService)
        {

            _providerService = providerService;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _providerService.GetData();
        }

        public async Task<IEnumerable<Country>> GetCountriesFilteredByName(string countryName)
        {
            var res = await _providerService.GetData();
            var lowerCaseSearch = countryName.ToLower();
            return res.Where(i => i.Name.Common.ToLower().Contains(lowerCaseSearch));
        }
    }
}
