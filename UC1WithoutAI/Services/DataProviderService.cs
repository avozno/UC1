using System.Collections;
using System.Diagnostics;
using System.Net.Http;
using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public class DataProviderService : IDataProviderService
    {
        private const string REST_COUNTRIES = "https://restcountries.com";
        private const string CURR_VER = "v3.1/all";
        private readonly HttpClient _client;
        private IEnumerable<Country> _countries;
        public DataProviderService(IHttpClientFactory _httpClientFactory)
        {
            _client = _httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(REST_COUNTRIES);
        }

        public async Task<IEnumerable<Country>> GetData()
        {
            if (_countries != null)
            {
                return _countries;
            }
            try
            {
                var res = await _client.GetFromJsonAsync<IEnumerable<Country>>(CURR_VER);
                _countries = res ?? new List<Country>();
                return _countries;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        } 


    }
}
