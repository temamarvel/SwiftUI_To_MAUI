using Microsoft.Maui.Handlers;
using View = Android.Views.View;

namespace MAUI_Library;

//Implement handler for Android platform here
public partial class HelloWorldHandler: ViewHandler<HelloWorldControl, Android.Views.View> {
    public HelloWorldHandler() : base(PropertyMapper) { }

    public static IPropertyMapper<HelloWorldControl, HelloWorldHandler> PropertyMapper =
        new PropertyMapper<HelloWorldControl, HelloWorldHandler>(ViewHandler.ViewMapper) { };
    
    protected override Android.Views.View CreatePlatformView() {
        //it is just a mock view
        //create something real for a correct implementation
        return new View(null);
    }
}