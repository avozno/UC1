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
            var data = LimitByPopulation(res, limit);
            return data;
        }

        public async Task<IEnumerable<Country>> GetCountriesOrderedByName(string orderDirection)
        {
            var res = await _providerService.GetData();
            return OrderByName(res, orderDirection);
        }

        public async Task<IEnumerable<Country>> GetCountriesWithPagination(int page, int itemsPerPage)
        {
            var res = await _providerService.GetData();
            return Paginate(res, page, itemsPerPage);
        }

        public async Task<IEnumerable<Country>> GetCountriesFiltered(string? search, short? limit, string? orderDirection, int? page, int? itemsPerPage)
        {
            IEnumerable<Country> res = await _providerService.GetData();
            if (search != null)
            {
                res = FilterByName(res, search);
            }
            if (limit != null)
            {
                res = LimitByPopulation(res, limit.Value);
            }
            if (orderDirection != null)
            {
                res = OrderByName(res, orderDirection);
            }
            if (page != null && itemsPerPage != null)
            {
                Paginate(res, page.Value, itemsPerPage.Value);
            }
            return res;
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

        private IEnumerable<Country> Paginate(IEnumerable<Country> list, int page, int itemsPerPage)
        {
            if (page < 0 || itemsPerPage < 0)
            {
                return new List<Country>();
            }
            return list.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
        }
    }
}
