namespace TekusProviders.Models
{
    public class DetailsServiceCountryTo
    {
        public DetailsServiceCountry DetailsServiceCountry { get; set; } = new DetailsServiceCountry();
        public Service Service { get; set; } = new Service();
        public Country Country { get; set; } = new Country();

    }
}
