using Microsoft.Maui.Handlers;
using View = Android.Views.View;

namespace MAUI_Library;

//Implement handler for Android platform here
public partial class SegmentedButtonsHandler: ViewHandler<SegmentedButtonsControl, Android.Views.View> {
    public SegmentedButtonsHandler() : base(PropertyMapper) { }

    public static IPropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler> PropertyMapper =
        new PropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler>(ViewHandler.ViewMapper) { };
    
    protected override Android.Views.View CreatePlatformView() {
        //it is just a mock view
        //create something real for a correct implementation
        return new View(null);
    }
}