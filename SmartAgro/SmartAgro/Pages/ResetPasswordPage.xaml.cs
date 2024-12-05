using SmartAgro.Models.RequestModels;
using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgroAPI.DataTransferObjects;

namespace SmartAgro.Pages;

public partial class ResetPasswordPage : ContentPage
{
    private string _email;
    private string _code;

    public ResetPasswordPage(string email, string code)
	{
        InitializeComponent();

        _email = email;
        _code = code;

    }
    private void ShowErrorMessage(string message)
    {
        ErrorMessage.Text = message;
        ErrorMessage.IsVisible = true;
        buttonConfirmation.IsEnabled = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        inputPassword.IsPassword = !inputPassword.IsPassword;
        passwordVisibility1.Text = inputPassword.IsPassword != true ? Application.Current!.Resources["SolidIconEye"].ToString() : Application.Current!.Resources["SolidIconEyeSlash"].ToString();

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        inputConfirmPassword.IsPassword = !inputConfirmPassword.IsPassword;
        passwordVisibility2.Text = inputConfirmPassword.IsPassword != true ? Application.Current!.Resources["SolidIconEye"].ToString() : Application.Current!.Resources["SolidIconEyeSlash"].ToString();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        buttonConfirmation.Text = "";
        buttonConfirmation.IsEnabled = false;
        buttonConfirmation.BackgroundColor = Color.FromHex("#AFE899");

        if (string.IsNullOrWhiteSpace(inputPassword.Text) ||
            string.IsNullOrWhiteSpace(inputConfirmPassword.Text))
        {
            ShowErrorMessage("Todos os campos devem estar preenchidos para que seja realizado a recuperação de senha");
            return;
        }

        if (!inputPassword.Text.Any(x => char.IsDigit(x)) ||
            !inputPassword.Text.Any(x => char.IsLetter(x)) ||
            !inputPassword.Text.Any(x => char.IsPunctuation(x)))
        {
            ShowErrorMessage("A senha deve conter letras, números e símbolos");
            return;
        }

        if (inputPassword.Text != inputConfirmPassword.Text)
        {
            ShowErrorMessage("As senhas devem ser iguais");
            return;
        }

        var reset = new ApiRequestResetPassword()
        {
            Email = _email,
            TemporaryToken = _code,
            NewPassword = inputPassword.Text
        };

        var request = await ApiService.Client.PostAsync(ApiRoutes.Reset, ApiService.ToBodyContent(reset));

        if (request.StatusCode == System.Net.HttpStatusCode.OK)
        {
            App.Current!.MainPage = new NavigationPage(new LoginPage());
        }
        else 
        { 
            ShowErrorMessage("Houve um erro na requisição");
        }
    }
}