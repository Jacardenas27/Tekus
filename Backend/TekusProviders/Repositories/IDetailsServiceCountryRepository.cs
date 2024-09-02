using TekusProviders.Models;

namespace TekusProviders.Repositories
{
    public interface IDetailsServiceCountryRepository
    {
        Task<IEnumerable<DetailsServiceCountry>> GetAll();
        Task<DetailsServiceCountry> GetById(Guid id);
        Task<DetailsServiceCountry> Add(DetailsServiceCountry detailsServiceCity);
        Task<DetailsServiceCountry> Update(DetailsServiceCountry detailsServiceCity);
        Task<IEnumerable<DetailsServiceCountryTo>> GetDetailsWithService();
    }
}
