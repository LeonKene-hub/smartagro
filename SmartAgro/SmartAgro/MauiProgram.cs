using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SmartAgro.Services;
using Syncfusion.Maui.Core.Hosting;

namespace SmartAgro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("fa6.otf", "FA");
                fonts.AddFont("fa6solid.otf", "FASolid");
                fonts.AddFont("Jost-Light.ttf", "JostLight");
                fonts.AddFont("Jost-Regular.ttf", "JostRegular");
                fonts.AddFont("Jost-Medium.ttf", "JostMedium");
                fonts.AddFont("Jost-SemiBold.ttf", "JostSemibold");
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}