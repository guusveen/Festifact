using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Festifact.Models;
using Festifact.Services;

namespace Festifact.ViewModels
{
    public class CreateFestivalViewModel
    {
        private readonly HttpClient httpClient;
        private readonly NavigationManager navigationManager;
        private readonly FestivalService festivalService;

        public CreateFestivalViewModel(
            HttpClient httpClient,
            NavigationManager navigationManager,
            FestivalService festivalService)
        {
            this.httpClient = httpClient;
            this.navigationManager = navigationManager;
            this.festivalService = festivalService;
        }

        public Festival Festival { get; set; } = new Festival();
        public string ErrorMessage { get; set; }

        public async Task CreateFestivalAsync()
        {
            Festival createdFestival = await festivalService.CreateFestivalAsync(Festival);
            if (createdFestival != null)
            {
                navigationManager.NavigateTo($"/edit-festival/{createdFestival.Id}");
            }
            else
            {
                ErrorMessage = "Failed to create Festival. Please try again.";
            }
        }
    }
}
