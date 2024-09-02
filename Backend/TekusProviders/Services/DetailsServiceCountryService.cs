using System.Buffers.Text;
using System.Net.Http.Headers;
using System.Text.Json;
using TekusProviders.Models;
using TekusProviders.Repositories;

namespace TekusProviders.Services
{
    public class DetailsServiceCountryService : IDetailsServiceCountryService
    {
        private readonly IDetailsServiceCountryRepository _repository;
        private readonly HttpClient _httpClient;

        public DetailsServiceCountryService(IDetailsServiceCountryRepository repository, HttpClient httpClient)
        {
            _repository = repository;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DetailsServiceCountry>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<DetailsServiceCountry> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<DetailsServiceCountry> Add(DetailsServiceCountry detailsServiceCity)
        {
            return await _repository.Add(detailsServiceCity);
        }

        public async Task<DetailsServiceCountry> Update(DetailsServiceCountry detailsServiceCity)
        {
            return await _repository.Update(detailsServiceCity);
        }

        public async Task<IEnumerable<DetailsServiceCountryTo>> GetDetailsWithService()
        {
            return await _repository.GetDetailsWithService();
        }

        public async Task<IEnumerable<Country>> GetCountriesFromExternalApi()
        {
            string token = await GetAccessTokenCountriesApi();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.universal-tutorial.com/api/countries/");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("Authorization", "Bearer " + token);
            HttpResponseMessage countriesResponse = await _httpClient.SendAsync(request);
            countriesResponse.EnsureSuccessStatusCode();
            var countriesData = await countriesResponse.Content.ReadAsStringAsync();
            Console.WriteLine(countriesData);
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return countries;
        }

        private async Task<string> GetAccessTokenCountriesApi()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.universal-tutorial.com/api/getaccesstoken");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("api-token", System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("dndTdENBSDNKNnNKc05fNWtaRWNwVURnZnl5TExCM25jUGt1NFNEQVdSckRNUWlMWmsxVlF3VjhxdEFFN013RlJNWQ==")));
            request.Headers.Add("user-email", System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("amluem9oLmdhbWVzQGdtYWlsLmNvbQ==")));
            HttpResponseMessage tokenRequest = await _httpClient.SendAsync(request);
            tokenRequest.EnsureSuccessStatusCode();
            var tokenResponse = await tokenRequest.Content.ReadAsStringAsync();
            var tokenData = JsonSerializer.Deserialize<Dictionary<string, string>>(tokenResponse);
            return tokenData["auth_token"];
        }
    }

}
