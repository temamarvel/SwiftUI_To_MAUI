using MAUI_Library;
using Microsoft.Extensions.Logging;

namespace MAUI_App;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(HelloWorldControl), typeof(HelloWorldHandler));
                handlers.AddHandler(typeof(SpinEditControl), typeof(SpinEditHandler));
                handlers.AddHandler(typeof(MaterialTextEditControl), typeof(MaterialTextEditHandler));
                handlers.AddHandler(typeof(SegmentedButtonsControl), typeof(SegmentedButtonsHandler));
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}