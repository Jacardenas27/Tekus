using TekusProviders.Models;
using TekusProviders.Repositories;

namespace TekusProviders.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await _providerRepository.GetAll();
        }

        public async Task<Provider> GetById(Guid id)
        {
            return await _providerRepository.GetById(id);
        }

        public async Task<Provider> Add(Provider entity)
        {
            return await _providerRepository.Add(entity);
        }

        public async Task<Provider> Update(Provider entity)
        {
            return await _providerRepository.Update(entity);
        }
    }
}
