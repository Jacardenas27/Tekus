using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TekusProviders.Data;
using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public class DetailsServiceCountryRepository : IDetailsServiceCountryRepository
    {
        private readonly ApplicationDbContext _context;

        public DetailsServiceCountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetailsServiceCountry>> GetAll()
        {
            return await _context.DetailsServiceCountry.ToListAsync();
        }

        public async Task<DetailsServiceCountry> GetById(Guid id)
        {
            return await _context.DetailsServiceCountry.FindAsync(id);
        }

        public async Task<DetailsServiceCountry> Add(DetailsServiceCountry detailsServiceCountry)
        {
            _context.DetailsServiceCountry.Add(detailsServiceCountry);
            await _context.SaveChangesAsync();
            return detailsServiceCountry;
        }

        public async Task<DetailsServiceCountry> Update(DetailsServiceCountry detailsServiceCountry)
        {
            _context.Entry(detailsServiceCountry).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return detailsServiceCountry;
        }

        public async Task<IEnumerable<DetailsServiceCountryTo>> GetDetailsWithService()
        {
            var query = from dsc in _context.DetailsServiceCountry
                        join s in _context.Services on dsc.IdService equals s.Id
                        select new DetailsServiceCountryTo
                        {
                            DetailsServiceCountry = dsc,
                            Service = s
                        };

            return query.ToList();
        }

    }
}
