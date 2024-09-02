using Microsoft.EntityFrameworkCore;
using TekusProviders.Data;
using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public class DetailsProviderServiceRepository : IDetailsProviderServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public DetailsProviderServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetailsProviderService>> GetAll()
        {
            return await _context.DetailsProviderService.ToListAsync();
        }

        public async Task<DetailsProviderService?> GetById(Guid id)
        {
            return await _context.DetailsProviderService.FindAsync(id);
        }

        public async Task<DetailsProviderService> Add(DetailsProviderService detailsProviderService)
        {
            _context.DetailsProviderService.Add(detailsProviderService);
            await _context.SaveChangesAsync();
            return detailsProviderService;
        }

        public async Task<DetailsProviderService> Update(DetailsProviderService detailsProviderService)
        {
            _context.Entry(detailsProviderService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return detailsProviderService;
        }

        public async Task<IEnumerable<DetailsProviderServiceTo>> GetDetailsWithProvidersAndServices()
        {
            var query = from dps in _context.DetailsProviderService
                        join p in _context.Providers on dps.IdProvider equals p.Id
                        join s in _context.Services on dps.IdService equals s.Id
                        select new DetailsProviderServiceTo
                        {
                            DetailsProviderService = dps,
                            Provider = p,
                            Service = s 
                        };

            return await query.ToListAsync();
        }
    }
}
