using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MovieXMLmitCHATGPT.Repositories;
using MovieXMLmitCHATGPT.ViewModels;
using System.Diagnostics;

namespace MovieXMLmitCHATGPT
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            var path = FileSystem.Current.AppDataDirectory;
            var path2 = "movies.xml";
            var filepath = Path.Combine(path, path2);
            Debug.WriteLine("Pfad: " + filepath);
            builder.Services.AddSingleton(new MovieRepository(filepath));
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
