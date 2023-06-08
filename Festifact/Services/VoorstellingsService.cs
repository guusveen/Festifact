using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Festifact.Models;

namespace Festifact.Services
{
    public class VoorstellingsService
    {
        private readonly HttpClient _httpClient;
        private const string Url = "/api/Voorstellings";

        public VoorstellingsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Voorstelling>> GetVoorstellingen()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Voorstelling>>();
        }

        public async Task<Voorstelling> GetVoorstelling(int id)
        {
            var response = await _httpClient.GetAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Voorstelling>();
        }

        public async Task<Voorstelling> CreateVoorstelling(Voorstelling voorstelling)
        {
            var response = await _httpClient.PostAsJsonAsync(Url, voorstelling);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Voorstelling>();
        }

        public async Task<Voorstelling> UpdateVoorstelling(int id, Voorstelling voorstelling)
        {
            var response = await _httpClient.PutAsJsonAsync($"{Url}/{id}", voorstelling);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Voorstelling>();
        }

        public async Task DeleteVoorstelling(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
