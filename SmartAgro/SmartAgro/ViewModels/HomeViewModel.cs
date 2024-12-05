using CommunityToolkit.Mvvm.ComponentModel;
using SmartAgro.Models.ViewModels;

namespace SmartAgro.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? greeting;

        [ObservableProperty]
        private string username;

        public HomeViewModel(ProfilePageViewModel profilePageViewModel)
        {
            Username = profilePageViewModel.Username ?? "Usuário";
            UpdateGreeting();
        }

        public void UpdateGreeting()
        {
            var currentTime = DateTime.Now.Hour;
            if (currentTime >= 6 && currentTime < 12)
                Greeting = $"Bom dia, {Username}";
            else if (currentTime >= 12 && currentTime < 18)
                Greeting = $"Boa tarde, {Username}";
            else
                Greeting = $"Boa noite, {Username}";
        }
    }
}
