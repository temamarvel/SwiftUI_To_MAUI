using Foundation;
using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class SpinEditHandler : ViewHandler<SpinEditControl, UIView> {
    private SpinEditWrapper Wrapper { get; set; }

    public SpinEditHandler() : base(PropertyMapper) {
    }

    private static IPropertyMapper<SpinEditControl, SpinEditHandler> PropertyMapper =
        new PropertyMapper<SpinEditControl, SpinEditHandler>(ViewMapper) {
            [nameof(SpinEditControl.Value)] = MapValue,
            [nameof(SpinEditControl.Interval)] = MapInterval,
            [nameof(SpinEditControl.BorderColor)] = MapBorderColor,
            [nameof(SpinEditControl.FocusedBorderColor)] = MapFocusedBorderColor,
        };

    private static void MapValue(SpinEditHandler handler, SpinEditControl spinEditControl) {
        if (handler == null || handler.Wrapper.Value == spinEditControl.Value)
            return;
        
        handler.Wrapper.Value= spinEditControl.Value;
    }

    private static void MapInterval(SpinEditHandler handler, SpinEditControl spinEditControl) {
        if (handler == null || handler.Wrapper.Interval == spinEditControl.Interval)
            return;
        
        handler.Wrapper.Interval = spinEditControl.Interval;
    }

    private static void MapBorderColor(SpinEditHandler handler, SpinEditControl spinEditControl) {
        var borderColor = spinEditControl.BorderColor.ToUIColor();
        if (handler == null || handler.Wrapper.BorderColor == borderColor)
            return;
        
        handler.Wrapper.BorderColor = borderColor;
    }

    private static void MapFocusedBorderColor(SpinEditHandler handler, SpinEditControl spinEditControl) {
        var focusedBorderColor = spinEditControl.FocusedBorderColor.ToUIColor();
        if (handler == null || handler.Wrapper.FocusedBorderColor == focusedBorderColor)
            return;
        
        handler.Wrapper.FocusedBorderColor = focusedBorderColor;
    }

    protected override UIView CreatePlatformView() {
        Wrapper = new SpinEditWrapper();
        Wrapper.OnValueChanged = OnValueChanged;
        Wrapper.OnIntervalChanged = OnIntervalChanged;
        return Wrapper.UiView;
    }

    private void OnValueChanged(NSDecimal value) => VirtualView.Value = (decimal)value;
    private void OnIntervalChanged(NSDecimal interval) => VirtualView.Interval = (decimal)interval;
}