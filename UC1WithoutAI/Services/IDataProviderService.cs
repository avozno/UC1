using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public interface IDataProviderService
    {
        Task<List<Country>> GetData();
    }
}
