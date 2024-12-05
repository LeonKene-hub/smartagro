using Newtonsoft.Json;
using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgroAPI.DataTransferObjects;
using SmartAgroAPI.Models;

namespace SmartAgro.Pages;

public partial class LoginPage : ContentPage
{

    public LoginPage()
    {
        InitializeComponent();

        inputEmail.Text = "wendermaiac@gmail.com";
        inputPassword.Text = "teste!123";
    }
    private void ShowErrorMessage(string message)
    {
        ErrorMessage.Text = message;
        ErrorMessage.IsVisible = true;
        buttonConfirmation.IsEnabled = true;
    }

    private void TapGestureRecognizer_Tapped_Password(object sender, TappedEventArgs e)
    {
        inputPassword.IsPassword = !inputPassword.IsPassword;
        passwordVisibility.Text = inputPassword.IsPassword != true ? Application.Current!.Resources["SolidIconEye"].ToString() : Application.Current!.Resources["SolidIconEyeSlash"].ToString();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        buttonConfirmation.Text = "";
        buttonConfirmation.IsEnabled = false;
        buttonConfirmation.BackgroundColor = Color.FromHex("#AFE899");

        if (string.IsNullOrWhiteSpace(inputEmail.Text) || string.IsNullOrWhiteSpace(inputPassword.Text))
        {
            ShowErrorMessage("Todos os campos devem estar preenchidos para que seja realizado o login");
            return;
        }

        var body = new ApiRequestUserAuthentication() { Email = inputEmail.Text, Password = inputPassword.Text };

        var request = await ApiService.Client.PostAsync(ApiRoutes.Login, ApiService.ToBodyContent(body));

        if (request.StatusCode != System.Net.HttpStatusCode.OK)
        {
            ShowErrorMessage("Email ou senha inválidos");
            return;
        }

        var result = await request.Desserialize<ApiRequestToken>();

        await SecureStorage.SetAsync("jwt_token", result!.Token);
        Data.loggedUser = result.user;

        ApiService.SetAuthToken(result!.Token);

        if (Data.loggedUser.Id != Guid.Empty)
        {
            App.Current!.MainPage = new NavigationPage(new HomePage());

        }
    }

    private void TapGestureRecognizer_Tapped_Register(object sender, TappedEventArgs e)
    {
        //Navega para a página de Registro 
        App.Current!.MainPage = new NavigationPage(new RegisterPage());
    }

    private async void TapGestureRegonizer_Tapped_Recover(object sender, TappedEventArgs e)
    {
        recoverPassword.IsEnabled = false;

        //Navega para a página de Esqueci a minha senha 
        if (string.IsNullOrWhiteSpace(inputEmail.Text))
        {
            ShowErrorMessage("Deve haver um email para que a senha seja redefinida");
            return;
        }

        var email = new ApiRequestRecoverPassword() { Email = inputEmail.Text };

        var request = await ApiService.Client.PostAsync(ApiRoutes.Recover, ApiService.ToBodyContent(email));

        if (request.StatusCode == System.Net.HttpStatusCode.OK)
        {
            App.Current!.MainPage = new NavigationPage(new RecoverAccountPage(inputEmail.Text.ToString()));
        }
        else 
        {
            ShowErrorMessage("Houve um erro na requisição");
            recoverPassword.IsEnabled = true;
            return;
        }
    }

    private void inputPassword_Focused(object sender, FocusEventArgs e)
    {
        ErrorMessage.IsVisible = false;
    }
}