using Foundation;
using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class SegmentedButtonsHandler : ViewHandler<SegmentedButtonsControl, UIView> {
    private SegmentedButtonsWrapper Wrapper { get; set; }

    public SegmentedButtonsHandler() : base(PropertyMapper) {
    }

    private static IPropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler> PropertyMapper =
        new PropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler>(ViewMapper) {
            [nameof(SegmentedButtonsControl.SelectedIndices)] = MapSelectedIndices,
            [nameof(SegmentedButtonsControl.AllowsMultipleSelection)] = MapAllowsMultipleSelection,
        };

    private static void MapAllowsMultipleSelection(SegmentedButtonsHandler handler, SegmentedButtonsControl control) {
        handler.Wrapper.AllowsMultipleSelection = control.AllowsMultipleSelection;
    }

    private static void MapSelectedIndices(SegmentedButtonsHandler handler, SegmentedButtonsControl control) {
        handler.Wrapper.SelectedIndices = control.SelectedIndices.ToNSNumbersArray();
    }

    protected override UIView CreatePlatformView() {
        Wrapper = new SegmentedButtonsWrapper();
        return Wrapper.UiView;
    }
}