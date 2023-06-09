using Festifact.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Festifact.Services
{
    public class BezoekerService
    {
        private readonly HttpClient _httpClient;

        public BezoekerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Bezoeker>> GetBezoekersAsync()
        {
            var response = await _httpClient.GetAsync("/api/bezoekers");
            //var bezoekers = System.Text.Json.JsonSerializer.Deserialize<List<Bezoeker>>(response);
            if (!response.IsSuccessStatusCode)
            {
                // Output something if the response is empty.
                Debug.Print("The response is empty.");
                return null;
            }
            //response.EnsureSuccessStatusCode();
            var bezoekers = await response.Content.ReadFromJsonAsync<List<Bezoeker>>();
            foreach (var item in bezoekers)
            {
                Debug.Print(item.Naam);
            }
            return bezoekers;
        }

        public async Task<Bezoeker> GetBezoekerAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/bezoekers/{id}");
            response.EnsureSuccessStatusCode();
            var bezoeker = await response.Content.ReadFromJsonAsync<Bezoeker>();
            return bezoeker;
        }

        public async Task<HttpResponseMessage> CreateBezoekerAsync(Bezoeker bezoeker)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/bezoekers", bezoeker);
            //response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> UpdateBezoekerAsync(int id, Bezoeker bezoeker)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/bezoekers/{id}", bezoeker);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> DeleteBezoekerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/bezoekers/{id}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
