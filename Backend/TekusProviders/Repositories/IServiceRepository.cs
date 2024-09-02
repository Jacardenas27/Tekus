using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAll();
        Task<Service> GetById(Guid id);
        Task<Service> Add(Service service);
        Task<Service> Update(Service service);
    }
}
