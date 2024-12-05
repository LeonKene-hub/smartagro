using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartAgro.Utils;

namespace SmartAgro.Models.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? username = Data.loggedUser.Name;

        [ObservableProperty]
        private string? email = Data.loggedUser.Email;

        [ObservableProperty]
        private string? phone = Data.loggedUser.Phone;

    }
}
