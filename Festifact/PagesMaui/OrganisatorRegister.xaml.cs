using Festifact.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Festifact.PagesMaui;

public partial class OrganisatorRegister : ContentPage
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public OrganisatorRegister(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;

        InitializeComponent();
    }
    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        var organisator = new Organisator();
        // Retrieve the values from the entry fields
        organisator.Email = EmailEntry.Text;
        organisator.Password = PasswordEntry.Text;
        organisator.Name = NameEntry.Text;

        // Perform the registration logic
        var registrationUrl = "api/Organisators/Register";

        try
        {
            var response = await _httpClient.PostAsJsonAsync(registrationUrl, organisator);

            if (response.IsSuccessStatusCode)
            {
                // Registration successful
                await DisplayAlert("Registration", "Registration succesful. You can now log in.", "OK");
                App.Current.MainPage.Navigation.PushAsync(new OrganisatorLogin(_httpClient));
            }
            else
            {
                // Registration failed
                await DisplayAlert("Registration", "Registration failed. Please try again.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}