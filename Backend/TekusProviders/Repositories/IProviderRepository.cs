using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetAll();
        Task<Provider> GetById(Guid id);
        Task<Provider> Add(Provider provider);
        Task<Provider> Update(Provider provider);
    }
}
