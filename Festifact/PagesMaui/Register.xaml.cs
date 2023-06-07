using Festifact.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;

namespace Festifact.PagesMaui;

public partial class Register : ContentPage
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public Register(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;

        InitializeComponent();
    }
    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        var bezoeker = new Bezoeker();
        // Retrieve the values from the entry fields
        bezoeker.Email = EmailEntry.Text;
        bezoeker.Password = PasswordEntry.Text;
        bezoeker.Naam = NameEntry.Text;
        bezoeker.Adres = AddressEntry.Text;
        bezoeker.Geboortedatum = BirthDatePicker.Date;

        // Perform the registration logic
        var registrationUrl = "api/Bezoekers/Register"; 

        try
        {
            var response = await _httpClient.PostAsJsonAsync(registrationUrl, bezoeker);

            if (response.IsSuccessStatusCode)
            {
                // Registration successful
                await DisplayAlert("Registration", "Registration succesful. You can now log in.", "OK");
                App.Current.MainPage.Navigation.PushAsync(new Login(_httpClient));
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