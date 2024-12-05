using Microsoft.Maui.Devices.Sensors;
using SmartAgro.Models.RequestModels;
using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgro.ViewModels;
using SmartAgroAPI.DataTransferObjects;
using System.Globalization;

namespace SmartAgro.Pages;

public partial class EditOrCreatePage : ContentPage
{

    public EditOrCreateViewModel vm = new EditOrCreateViewModel();
    private bool isNewRegistration;
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    private string apiKey = "d98a3ffaf90646da977124924242911";
    private Location location = new Location();
    private ApiRequestSensor _sensor;
    public DateTime? DataSelecionada { get; set; }

    public EditOrCreatePage(bool isNewRegistration)
	{
		InitializeComponent();

        this.isNewRegistration = isNewRegistration;

        BindingContext = vm;

        DataSelecionada = DateTime.Now;

        // Lógica condicional baseada em isNewRegistration
        if (isNewRegistration)
        {
            Title = "Novo Cadastro de Baia";
        }
        else
        {
            Title = "Edição de Baia";
            // Carregar dados existentes para edição
            LoadExistingData();
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        GetCurrentLocation();
    }


    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            // Configurando a solicitação de localização
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            // Obtendo a localização atual
            location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                //Garantindo que as coordenadas usem pontos decimais, por algum motivo nao estava indo sem 😎
                string latitude = location.Latitude.ToString(CultureInfo.InvariantCulture);
                string longitude = location.Longitude.ToString(CultureInfo.InvariantCulture);

                string url = $"https://api.weatherapi.com/v1/current.json?q={latitude},{longitude}&key={apiKey}";

                Console.WriteLine($"URL da API: {url}");
            }
            else
            {
                Console.WriteLine("Não foi possível obter a localização.");
            }
        }
        catch (FeatureNotSupportedException)
        {
            Console.WriteLine("Recurso de geolocalização não suportado neste dispositivo.");
        }
        catch (FeatureNotEnabledException)
        {
            Console.WriteLine("Recurso de geolocalização está desativado. Ative-o nas configurações.");
        }
        catch (PermissionException)
        {
            Console.WriteLine("Permissão de localização negada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }


    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(inputName.Text) ||
            
            string.IsNullOrWhiteSpace(inputUmidadeAr.Text) ||
            string.IsNullOrWhiteSpace(inputUmidadeSolo.Text) ||
            string.IsNullOrWhiteSpace(inputTemperaturaAr.Text) ||
            string.IsNullOrWhiteSpace(inputTemperaturaSolo.Text) ||
            string.IsNullOrWhiteSpace(inputPh.Text) ||
            string.IsNullOrWhiteSpace(inputLuminosidade.Text))
        {
            await DisplayAlert("Erro", "Por favor, preencha todos os campos obrigatórios.", "OK");
            return;
        }

        Categoria selectedCategoria = categorias.SelectedItem as Categoria;
        int categoryId = selectedCategoria?.ID ?? 0;

        DateTime? selectedDate = datePicker.SelectedDate;

        var dataColheita = selectedDate.Value.ToString("yyyy-MM-dd");

        _sensor = new ApiRequestSensor()
        {
            CategoryId = categoryId,
            SensorName = inputName.Text,
            DataColheita = DateOnly.ParseExact(dataColheita, "yyyy-MM-dd"),
            Latitude = (decimal?)location.Latitude,
            Longitude = (decimal?)location.Longitude,
            UmidadeArIdeal = decimal.TryParse(inputUmidadeAr.Text, out decimal umidadeAr) ? umidadeAr : null,
            UmidadeSoloIdeal = decimal.TryParse(inputUmidadeSolo.Text, out decimal umidadeSolo) ? umidadeSolo : null,
            TemperaturaArIdeal = decimal.TryParse(inputTemperaturaAr.Text, out decimal temperaturaAr) ? temperaturaAr : null,
            TemperaturaSoloIdeal = decimal.TryParse(inputTemperaturaSolo.Text, out decimal temperaturaSolo) ? temperaturaSolo : null,
            PhSoloIdeal = decimal.TryParse(inputPh.Text, out decimal ph) ? ph : null,
            LuminosidadeIdeal = decimal.TryParse(inputLuminosidade.Text, out decimal luminosidade) ? luminosidade : null,
            UsuarioId = Data.loggedUser.Id,
        };


        var request = await ApiService.Client.PostAsync(ApiRoutes.SensorPost, ApiService.ToBodyContent(_sensor));

        if (!request.IsSuccessStatusCode)
        {
            string responseBody = await request.Content.ReadAsStringAsync();
            Console.WriteLine($"Falha na criação do sensor. Status code: {request.StatusCode}\nDetalhes: {responseBody}");
            await DisplayAlert("Erro", $"Falha na criação do sensor. Status code: {request.StatusCode}\nDetalhes: {responseBody}", "OK");
            return;
        }
        
        await DisplayAlert("Sucesso", "Sensor cadastrado com sucesso!", "OK");
    }


    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        App.Current!.MainPage = new NavigationPage(new HomePage());
    }

    private void LoadExistingData()
    {
        // Implementação para carregar dados existentes
    }
}