using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace EmployeeAttendanceMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("PoppinsBold.ttf", "PoppinsBold");
                    fonts.AddFont("PoppinsExtraBold.ttf", "PoppinsExtraBold");
                    fonts.AddFont("PoppinsMedium.ttf", "PoppinsMedium");
                    fonts.AddFont("PoppinsRegular.ttf", "PoppinsRegular");
                    fonts.AddFont("PoppinsSemiBold.ttf", "PoppinsSemiBold");
                    fonts.AddFont("fontawsome.ttf", "FontAwesome");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
