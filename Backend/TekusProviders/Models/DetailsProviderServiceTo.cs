namespace TekusProviders.Models
{
    public class DetailsProviderServiceTo
    {
        public DetailsProviderService DetailsProviderService { get; set; } = new DetailsProviderService();
        public Provider Provider { get; set; } = new Provider();
        public Service Service { get; set; } = new Service();
    }
}
