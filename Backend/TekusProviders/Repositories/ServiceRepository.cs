using Microsoft.EntityFrameworkCore;
using TekusProviders.Data;
using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service?> GetById(Guid id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<Service> Add(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> Update(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return service;
        }
    }
}
