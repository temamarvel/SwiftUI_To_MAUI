using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class HelloWorldHandler : ViewHandler<HelloWorldControl, UIView> {
    public HelloWorldHandler() : base(PropertyMapper) { }

    public static IPropertyMapper<HelloWorldControl, HelloWorldHandler> PropertyMapper =
        new PropertyMapper<HelloWorldControl, HelloWorldHandler>(ViewHandler.ViewMapper) { };

    protected override UIView CreatePlatformView() {
        var wrapper = new HelloWorldWrapper();
        return wrapper.UiView;
    }
}