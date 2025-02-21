using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using ViewModel;

namespace BentchingProgram2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            Assembly a = Assembly.GetExecutingAssembly();
            var stream = a.GetManifestResourceStream($"{typeof(Settings).Namespace}.secret-appsettings.json");
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Configuration.AddConfiguration(config);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ViewModelBinder>();
            MauiApp app = builder.Build();

            IConfiguration? configval = app.Services.GetService<IConfiguration>();
            Settings? settingsval = configval.GetRequiredSection("Settings").Get<Settings>();

            App.ConnectionStringSetting = settingsval.conn.ToString();
            ConnManager.SetConnString(App.ConnectionStringSetting);

            return app;
        }
    }
}
