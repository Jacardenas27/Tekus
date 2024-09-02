using Microsoft.EntityFrameworkCore;
using TekusProviders.Data;
using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task<Provider?> GetById(Guid id)
        {
            return await _context.Providers.FindAsync(id);
        }

        public async Task<Provider> Add(Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> Update(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return provider;
        }
    }
}
