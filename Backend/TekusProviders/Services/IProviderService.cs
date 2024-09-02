using TekusProviders.Models;

namespace TekusProviders.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetAll();
        Task<Provider> GetById(Guid id);
        Task<Provider> Add(Provider entity);
        Task<Provider> Update(Provider entity);
    }
}
