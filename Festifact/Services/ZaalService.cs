using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Festifact.Models;

namespace Festifact.Services
{
    public class ZaalsService
    {
        private readonly HttpClient _httpClient;
        private const string Url = "/api/Zaals"; 

        public ZaalsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Zaal>> GetZalen()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Zaal>>();
        }

        public async Task<Zaal> GetZaal(int id)
        {
            var response = await _httpClient.GetAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Zaal>();
        }

        public async Task<Zaal> CreateZaal(Zaal zaal)
        {
            var response = await _httpClient.PostAsJsonAsync(Url, zaal);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Zaal>();
        }

        public async Task<Zaal> UpdateZaal(int id, Zaal zaal)
        {
            var response = await _httpClient.PutAsJsonAsync($"{Url}/{id}", zaal);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Zaal>();
        }

        public async Task DeleteZaal(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Url}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
