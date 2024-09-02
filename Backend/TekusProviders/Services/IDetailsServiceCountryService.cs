using TekusProviders.Models;

namespace TekusProviders.Services
{
    public interface IDetailsServiceCountryService
    {
        Task<IEnumerable<DetailsServiceCountry>> GetAll();
        Task<DetailsServiceCountry> GetById(Guid id);
        Task<DetailsServiceCountry> Add(DetailsServiceCountry detailsServiceCity);
        Task<DetailsServiceCountry> Update(DetailsServiceCountry detailsServiceCity);
        Task<IEnumerable<DetailsServiceCountryTo>> GetDetailsWithService();
        Task<IEnumerable<Country>> GetCountriesFromExternalApi();
    }
}
