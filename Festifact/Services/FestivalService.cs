using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Festifact.Models;

namespace Festifact.Services
{
    public class FestivalService
    {
        private readonly HttpClient httpClient;

        public FestivalService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Festival> GetFestivalByIdAsync(string id)
        {
            return await httpClient.GetFromJsonAsync<Festival>($"/api/Festivals/{id}");
        }

        public async Task<List<Locatie>> GetLocatiesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Locatie>>("/api/Locaties");
        }

        public async Task<bool> UpdateFestivalAsync(string id, Festival festival)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync($"/api/Festivals/{id}", festival);
            return response.IsSuccessStatusCode;
        }
    }
}
