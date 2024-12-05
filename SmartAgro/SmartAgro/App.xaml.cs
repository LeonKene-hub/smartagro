using SmartAgro.Pages;
using SmartAgro.Utils;

namespace SmartAgro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense(SECRETS.SYNCFUSION_KEY);
            MainPage = new LoginPage();
        }
    }
}
