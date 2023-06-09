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
    public class OrganisatorService
    {
        private readonly HttpClient _httpClient;

        public OrganisatorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Organisator>> GetOrganisatorsAsync()
        {
            var response = await _httpClient.GetAsync("/api/organisators");
            //var organisators = System.Text.Json.JsonSerializer.Deserialize<List<Organisator>>(response);
            if (!response.IsSuccessStatusCode)
            {
                // Output something if the response is empty.
                Debug.Print("The response is empty.");
                return null;
            }
            //response.EnsureSuccessStatusCode();
            var organisators = await response.Content.ReadFromJsonAsync<List<Organisator>>();
            foreach( var item in organisators )
            {
                Debug.Print(item.Name);
            }
            return organisators;
        }

        public async Task<Organisator> GetOrganisatorAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/organisators/{id}");
            response.EnsureSuccessStatusCode();
            var organisator = await response.Content.ReadFromJsonAsync<Organisator>();
            return organisator;
        }

        public async Task<HttpResponseMessage> CreateOrganisatorAsync(Organisator organisator)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/organisators", organisator);
            //response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> UpdateOrganisatorAsync(int id, Organisator organisator)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/organisators/{id}", organisator);
            //response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> DeleteOrganisatorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/organisators/{id}");
            //response.EnsureSuccessStatusCode();
            return response;
        }
    }
}

