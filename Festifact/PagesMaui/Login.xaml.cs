using System.Net.Http.Json;
using Festifact.Models;

namespace Festifact.PagesMaui;

public partial class Login : ContentPage
{
    private readonly HttpClient _httpClient;

    public Login(HttpClient httpClient)
    {
        _httpClient = httpClient;
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        // Perform the login logic
        var loginModel = new Bezoeker { Email = email, Password = password };
        var response = await _httpClient.PostAsJsonAsync("/api/Bezoekers/Login", loginModel);

        if (response.IsSuccessStatusCode)
        {
            // Login successful
            var bezoeker = await response.Content.ReadFromJsonAsync<Bezoeker>();
            // Save the user data or perform further actions
            // Storing user preferences
            Preferences.Set("LoggedInUserId", bezoeker.Id.ToString());
            Preferences.Set("LoggedInUserEmail", bezoeker.Email);
            Preferences.Set("LoggedInUserName", bezoeker.Naam);
            Preferences.Set("LoggedInUserAddress", bezoeker.Adres);
            Preferences.Set("LoggedInUserBirthdate", bezoeker.Geboortedatum.Value.ToShortTimeString());
            Preferences.Set("LoggedInUserType", "Bezoeker");
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