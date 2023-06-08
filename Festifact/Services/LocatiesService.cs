using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Festifact.Models;

namespace Festifact.Services
{
    public class LocatiesService
    {
        private readonly HttpClient _httpClient;
        private const string Url = "/api/Locaties";

        public LocatiesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Locatie>> GetLocaties()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Locatie>>();
        }

        public async Task<Locatie> GetLocatie(int id)
        {
            var response = await _httpClient.GetAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Locatie>();
        }

        public async Task<Locatie> CreateLocatie(Locatie locatie)
        {
            var response = await _httpClient.PostAsJsonAsync(Url, locatie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Locatie>();
        }

        public async Task<Locatie> UpdateLocatie(int id, Locatie locatie)
        {
            var response = await _httpClient.PutAsJsonAsync($"{Url}/{id}", locatie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Locatie>();
        }

        public async Task DeleteLocatie(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
