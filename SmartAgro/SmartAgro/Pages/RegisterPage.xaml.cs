using SmartAgro.Services;
using SmartAgro.Utils;
using SmartAgroAPI.DataTransferObjects;

namespace SmartAgro.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
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
        passwordVisibility1.Text = inputPassword.IsPassword != true ? Application.Current.Resources["SolidIconEye"].ToString() : Application.Current.Resources["SolidIconEyeSlash"].ToString();
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        inputConfirmPassword.IsPassword = !inputConfirmPassword.IsPassword;
        passwordVisibility2.Text = inputConfirmPassword.IsPassword != true ? Application.Current.Resources["SolidIconEye"].ToString() : Application.Current.Resources["SolidIconEyeSlash"].ToString();
    }

    private void TapGestureRecognizer_Tapped_Login(object sender, TappedEventArgs e)
    {
        // Navega para a página de login
        App.Current!.MainPage = new NavigationPage(new LoginPage());
    }

    private async void Button_Pressed(object sender, EventArgs e)
    {
        buttonConfirmation.Text = "";
        buttonConfirmation.IsEnabled = false;
        buttonConfirmation.BackgroundColor = Color.FromHex("#AFE899");

        if (string.IsNullOrWhiteSpace(inputName.Text) ||
            string.IsNullOrWhiteSpace(inputEmail.Text) ||
            string.IsNullOrWhiteSpace(inputPhone.Text) ||
            string.IsNullOrWhiteSpace(inputPassword.Text) ||
            string.IsNullOrWhiteSpace(inputConfirmPassword.Text))
        {
            ShowErrorMessage("Todos os campos devem estar preenchidos para que seja realizado o cadastro");
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

        var body = new ApiRequestUserRegister()
        {
            Name = inputName.Text,
            Email = inputEmail.Text,
            Phone = inputPhone.Text,
            Password = inputPassword.Text
        };

        var response = await ApiService.Client.PostAsync(ApiRoutes.User, ApiService.ToBodyContent(body));

        if (response.IsSuccessStatusCode)
        {
            App.Current!.MainPage = new NavigationPage(new LoginPage());
        }
        else
        {
            ShowErrorMessage("Ocorreu um erro durante o cadastro. Tente novamente.");
        }
    }   
}

