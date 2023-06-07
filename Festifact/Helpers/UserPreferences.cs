using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace Festifact.Helpers
{
    public class UserPreferences : INotifyPropertyChanged
    {
        private static UserPreferences instance;
        private readonly IConfiguration configuration;

        public event PropertyChangedEventHandler PropertyChanged;

        private string loggedInUserType;
        public string LoggedInUserType
        {
            get { return loggedInUserType; }
            set
            {
                if (loggedInUserType != value)
                {
                    loggedInUserType = value;
                    OnPropertyChanged(nameof(LoggedInUserType));
                }
            }
        }

        private UserPreferences(IConfiguration configuration)
        {
            this.configuration = configuration;
            LoadUserType();
        }

        public static UserPreferences Instance(IConfiguration configuration)
        {
            if (instance == null)
                instance = new UserPreferences(configuration);
            return instance;
        }

        private void LoadUserType()
        {
            LoggedInUserType = configuration.GetValue<string>("LoggedInUserType");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
