using TekusProviders.Models;
using TekusProviders.Repositories;

namespace TekusProviders.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _serviceRepository.GetAll();
        }

        public async Task<Service> GetById(Guid id)
        {
            return await _serviceRepository.GetById(id);
        }

        public async Task<Service> Add(Service service)
        {
            return await _serviceRepository.Add(service);
        }

        public async Task<Service> Update(Service service)
        {
            return await _serviceRepository.Update(service);
        }
    }
}
