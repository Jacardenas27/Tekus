using TekusProviders.Models;
using TekusProviders.Repositories;

namespace TekusProviders.Services
{
    public class DetailsProviderServiceService : IDetailsProviderServiceService
    {
        private readonly IDetailsProviderServiceRepository _repository;

        public DetailsProviderServiceService(IDetailsProviderServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DetailsProviderService>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<DetailsProviderService> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DetailsProviderService> Add(DetailsProviderService detailsProviderService)
        {
            return await _repository.Add(detailsProviderService);
        }

        public async Task<DetailsProviderService> Update(DetailsProviderService detailsProviderService)
        {
            return await _repository.Update(detailsProviderService);
        }

        public async Task<IEnumerable<DetailsProviderServiceTo>> GetDetailsWithProvidersAndServices()
        {
            return await _repository.GetDetailsWithProvidersAndServices();
        }
    }
}
