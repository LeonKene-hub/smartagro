using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgro.ViewModels;
using SmartAgroAPI.DataTransferObjects;

namespace SmartAgro.Pages;

public partial class HomePage : ContentPage
{
    public HomeViewModel vm = new HomeViewModel(new Models.ViewModels.ProfilePageViewModel());

    public HomePage()
	{
		InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.UpdateGreeting();
        GetUserData();
    }

    public async void GetUserData()
    {
        Data.sensorList.Clear();

        var request = await ApiService.Client.GetAsync(ApiRoutes.HomeRequest + Data.loggedUser.Id.ToString());

        if (!request.IsSuccessStatusCode)
        {
            return;
        }

        var sensors = await ApiService.DesserializeList<ApiRequestSensor>(request);

        foreach (var sensor in sensors)
        {
            Data.sensorList.Add(sensor);
        }

        //IMPORTANTE!!!
        sensorView.ItemsSource = Data.sensorList;
    }

    private void TapGestureRecognizer_Tapped_SensorPage(object sender, TappedEventArgs e)
    {
        var Obj = ((Border)sender).BindingContext as ApiRequestSensor;
        Navigation.PushAsync(new SensorPage(Obj));
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new NotificationPage());
    }

    private void TapGestureRecognizer_Tapped_ProfilePage(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }

    private void TapGestureRecognizer_edit_or_create(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new EditOrCreatePage(true));

    }


}