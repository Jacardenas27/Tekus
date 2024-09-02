using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public interface IDetailsProviderServiceRepository
    {
        Task<IEnumerable<DetailsProviderService>> GetAll();
        Task<DetailsProviderService> GetById(Guid id);
        Task<DetailsProviderService> Add(DetailsProviderService detailsProviderService);
        Task<DetailsProviderService> Update(DetailsProviderService detailsProviderService);
        Task<IEnumerable<DetailsProviderServiceTo>> GetDetailsWithProvidersAndServices();
    }
}
