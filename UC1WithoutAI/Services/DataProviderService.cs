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
        private List<Country>? _countries = null;
        public DataProviderService(IHttpClientFactory _httpClientFactory)
        {
            _client = _httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(REST_COUNTRIES);
        }

        public async Task<List<Country>> GetData()
        {
            if (_countries != null)
            {
                return _countries;
            }
            try
            {
                var res = await _client.GetFromJsonAsync<List<Country>>(CURR_VER);
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
