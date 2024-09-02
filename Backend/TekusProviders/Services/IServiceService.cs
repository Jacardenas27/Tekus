using TekusProviders.Models;

namespace TekusProviders.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetById(Guid id);
        Task<Service> Add(Service service);
        Task<Service> Update(Service service);
    }
}
