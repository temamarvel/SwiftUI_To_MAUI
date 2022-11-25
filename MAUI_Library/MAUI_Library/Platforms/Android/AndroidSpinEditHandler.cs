using Android.Widget;
using Microsoft.Maui.Handlers;
using View = Android.Views.View;

namespace MAUI_Library;

//Implement handler for Android platform here
public partial class SpinEditHandler: ViewHandler<SpinEditControl, Android.Views.View> {
    public SpinEditHandler() : base(PropertyMapper) { }

    public static IPropertyMapper<SpinEditControl, SpinEditHandler> PropertyMapper =
        new PropertyMapper<SpinEditControl, SpinEditHandler>(ViewHandler.ViewMapper) { };
    
    protected override Android.Views.View CreatePlatformView() {
        //it is just a mock view
        //create something real for a correct implementation
        return new View(null);
    }
}