using Foundation;
using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class SpinEditHandler : ViewHandler<SpinEditControl, UIView> {
    public SpinEditWrapper Wrapper { get; set; }

    public SpinEditHandler() : base(PropertyMapper) {
    }

    public static IPropertyMapper<SpinEditControl, SpinEditHandler> PropertyMapper =
        new PropertyMapper<SpinEditControl, SpinEditHandler>(ViewMapper) {
            [nameof(SpinEditControl.Value)] = MapValue,
            //[nameof(SpinEditControl.Interval)] = MapInterval,
        };

    static void MapValue(SpinEditHandler handler, SpinEditControl spinEditControl) {
        if (handler == null || handler.Wrapper.Value == spinEditControl.Value)
            return;

        handler.Wrapper.Value = (NSDecimal)spinEditControl.Value;
    }
    
    static void MapInterval(SpinEditHandler handler, SpinEditControl spinEditControl) {
        if (handler == null || handler.Wrapper.Interval == spinEditControl.Interval)
            return;
        handler.Wrapper.Interval = (NSDecimal)spinEditControl.Interval;
    }

    protected override UIView CreatePlatformView() {
        Wrapper = new SpinEditWrapper();
        Wrapper.OnValueChanged = OnValueChanged;
        //Wrapper.OnIntervalChanged = OnIntervalChanged;
        return Wrapper.UiView;
    }

    void OnValueChanged(NSDecimal value) => VirtualView.Value = (decimal)value;
    //void OnIntervalChanged(NSDecimal interval) => VirtualView.Interval = (decimal)interval;
}