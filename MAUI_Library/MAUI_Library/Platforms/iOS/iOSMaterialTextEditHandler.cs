using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class MaterialTextEditHandler : ViewHandler<MaterialTextEditControl, UIView> {
    private MaterialTextEditWrapper Wrapper { get; set; }

    public MaterialTextEditHandler() : base(PropertyMapper) {
    }

    private static IPropertyMapper<MaterialTextEditControl, MaterialTextEditHandler> PropertyMapper =
        new PropertyMapper<MaterialTextEditControl, MaterialTextEditHandler>(ViewMapper) {
            [nameof(MaterialTextEditControl.LeadingIconSource)] = MapLeadingIconSource,
        };

    private static void MapLeadingIconSource(MaterialTextEditHandler handler, MaterialTextEditControl materialTextEditControl) {
        handler.Wrapper.LeadingIcon = materialTextEditControl.LeadingIconSource.GetPlatformImageAsync(handler.MauiContext).Result.Value;
    }

    protected override UIView CreatePlatformView() {
        Wrapper = new MaterialTextEditWrapper();
        return Wrapper.UiView;
    }
}