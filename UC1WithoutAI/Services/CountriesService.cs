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
            return FilterByName(res, countryName);
        }

        public async Task<IEnumerable<Country>> GetCountriesLimitedByPopulationInMillions(short limit)
        {
            var res = await _providerService.GetData();
            return LimitByPopulation(res, limit);
        }

        public async Task<IEnumerable<Country>> GetCountriesOrderedByName(string orderDirection)
        {
            var res = await _providerService.GetData();
            return OrderByName(res, orderDirection);
        }

        private IEnumerable<Country> FilterByName(IEnumerable<Country> list, string filter)
        {
            var lowerCaseSearch = filter.ToLower();
            return list.Where(i => !string.IsNullOrEmpty(i.Name.Common) && i.Name.Common.ToLower().Contains(lowerCaseSearch));
        }

        private IEnumerable<Country> LimitByPopulation(IEnumerable<Country> list, short limit)
        {
            var limitInMillions = limit * _limitMultiplier;
            return list.Where(i => i.Population.HasValue && i.Population.Value < limitInMillions);
        }

        private IEnumerable<Country> OrderByName(IEnumerable<Country> list, string orderDirection)
        {
            if (orderDirection.ToLower() == "ascend")
            {
                return list.OrderBy(i => i.Name.Common);
            }
            if (orderDirection.ToLower() == "descend")
            {
                return list.OrderByDescending(i => i.Name.Common);
            }
            return list;
        }
    }
}
