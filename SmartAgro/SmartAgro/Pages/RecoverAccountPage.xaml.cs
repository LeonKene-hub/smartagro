using SmartAgro.Models.RequestModels;
using SmartAgro.Services;
using SmartAgro.Utils;

namespace SmartAgro.Pages;

public partial class RecoverAccountPage : ContentPage
{
    private string _email;
	public RecoverAccountPage(string email)
	{
		InitializeComponent();

        _email = email;

        EmailLabel.Text = _email;
    }

    private void ShowErrorMessage(string message)
    {
        ErrorMessage.Text = message;
        ErrorMessage.IsVisible = true;
        buttonConfirmation.IsEnabled = true;
    }

    private void number1_TextChanged(object sender, TextChangedEventArgs e)
    {
        number2.Focus();
        if (string.IsNullOrEmpty(number1.Text))
        {
            number1.Focus();
            return; 
        }

    }

    private void number2_TextChanged(object sender, TextChangedEventArgs e)
    {
        number3.Focus();
        if (string.IsNullOrEmpty(number2.Text))
        {
            number1.Focus();
            return;
        }
    }

    private void number3_TextChanged(object sender, TextChangedEventArgs e)
    {
        number4.Focus();
        if (string.IsNullOrEmpty(number3.Text))
        {
            number2.Focus();
            return;
        }
    }

    private void number4_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(number4.Text))
        {
            number3.Focus();
            return;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        buttonConfirmation.Text = "";
        buttonConfirmation.IsEnabled = false;
        buttonConfirmation.BackgroundColor = Color.FromHex("#AFE899"); 

        if (string.IsNullOrWhiteSpace(number1.Text) ||
            string.IsNullOrWhiteSpace(number2.Text) ||
            string.IsNullOrWhiteSpace(number3.Text) ||
            string.IsNullOrWhiteSpace(number4.Text))
        {
            ShowErrorMessage("Todos os campos devem estar preenchidos para a verificação");
            return;
        }

        var verifyInfo = new ApiRequestVerifyCode
        {
            Email = _email,
            Code = number1.Text + number2.Text + number3.Text + number4.Text
        };

        var request = await ApiService.Client.PostAsync(ApiRoutes.VerifyCode, ApiService.ToBodyContent(verifyInfo));

        if (request.StatusCode == System.Net.HttpStatusCode.OK)
        {
            App.Current!.MainPage = new NavigationPage(new ResetPasswordPage(verifyInfo.Email, verifyInfo.Code));
        }
        else 
        { 
            ShowErrorMessage("O código enviado não está correto");
        }
    }

    private void TapGestureRecognizer_Tapped_Login(object sender, TappedEventArgs e)
    {
        // Navega para a página de login
        App.Current!.MainPage = new NavigationPage(new LoginPage());
    }

}