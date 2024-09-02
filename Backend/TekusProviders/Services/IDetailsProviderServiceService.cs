using TekusProviders.Models;

namespace TekusProviders.Services
{
    public interface IDetailsProviderServiceService
    {
        Task<IEnumerable<DetailsProviderService>> GetAll();
        Task<DetailsProviderService> GetById(Guid id);
        Task<DetailsProviderService> Add(DetailsProviderService detailsProviderService);
        Task<DetailsProviderService> Update(DetailsProviderService detailsProviderService);
        Task<IEnumerable<DetailsProviderServiceTo>> GetDetailsWithProvidersAndServices();
    }
}
