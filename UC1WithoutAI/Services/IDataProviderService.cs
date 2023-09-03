using UCWithoutAi.Models;

namespace UCWithoutAi.Services
{
    public interface IDataProviderService
    {
        Task<IEnumerable<Country>> GetData();
    }
}
