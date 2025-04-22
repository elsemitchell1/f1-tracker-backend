using System.Net.Http;
using System.Threading.Tasks;

namespace F1TrackerApi.Services
{
    public class ErgastApiService
    {
        private readonly HttpClient _httpClient;

        public ErgastApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCurrentStandingsAsync()
        {
            // This calls the Ergast API for current driver standings
            var url = "https://api.jolpi.ca/ergast/f1/current/driverStandings.json";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throws an exception if not 200 OK

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetCurrentConstructorStandingsAsync()
        {
            // This calls the Ergast API for current driver standings
            var url = "https://api.jolpi.ca/ergast/f1/current/constructorStandings.json";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throws an exception if not 200 OK

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetCurrentRaceResultsAsync()
        {
            // This calls the Ergast API for current driver standings
            var url = "https://api.jolpi.ca/ergast/f1/current/results.json";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throws an exception if not 200 OK

            return await response.Content.ReadAsStringAsync();
        }
    }
}
