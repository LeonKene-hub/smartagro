
using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgro.ViewModels;
using SmartAgroAPI.DataTransferObjects;
using SmartAgroAPI.Models;
using SmartAgroAPI.ViewModels;

namespace SmartAgro.Pages;

public partial class NotificationPage : ContentPage
{
    public NotificationPage()
    {
        InitializeComponent();
        BindingContext = new NotificationViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GetNotifications();
    }

    public async void GetNotifications()
    {
        Data.notificationList.Clear();

        try
        {
            var request = await ApiService.Client.GetAsync(ApiRoutes.Notification);

            if (!request.IsSuccessStatusCode)
            {
                await DisplayAlert("Erro", "N�o foi poss�vel carregar as notifica��es.", "OK");
                return;
            }

            var notifications = await ApiService.DesserializeList<ApiRequestNotification>(request);

            foreach (var notification in notifications)
            {
                Data.notificationList.Add(notification);
            }

            // Atualiza a exibi��o no CollectionView
            notificationView.ItemsSource = Data.notificationList;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Falha ao carregar notifica��es: {ex.Message}", "OK");
        }
    }
}
