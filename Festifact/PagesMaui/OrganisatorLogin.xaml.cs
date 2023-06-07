using Festifact.Models;
using System.Net.Http.Json;

namespace Festifact.PagesMaui;

public partial class OrganisatorLogin : ContentPage
{
    private readonly HttpClient _httpClient;

    public OrganisatorLogin(HttpClient httpClient)
    {
        _httpClient = httpClient;
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        // Perform the login logic
        var loginModel = new Organisator { Email = email, Password = password };
        var response = await _httpClient.PostAsJsonAsync("/api/Organisators/Login", loginModel);

        if (response.IsSuccessStatusCode)
        {
            // Login successful
            var organisator = await response.Content.ReadFromJsonAsync<Organisator>();
            // Save the user data 
            Preferences.Set("LoggedInUserId", organisator.Id.ToString());
            Preferences.Set("LoggedInUserEmail", organisator.Email);
            Preferences.Set("LoggedInUserName", organisator.Name);
            Preferences.Set("LoggedInUserType", "Organisator");
            // wrap mainpage in navigationpage so the navigation links still work when we navigate back.
            App.Current.MainPage = new NavigationPage(new MainPage());
            await DisplayAlert("Login", "Login successful!", "OK");
        }
        else
        {
            // Login failed
            await DisplayAlert("Login", "Invalid credentials. Please try again.", "OK");
        }
    }
}