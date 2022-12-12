using Microsoft.Maui.Handlers;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace MAUI_Library;

public partial class SegmentedButtonsHandler : ViewHandler<SegmentedButtonsControl, UIView> {
    private SegmentedButtonsWrapper Wrapper { get; set; }

    public SegmentedButtonsHandler() : base(PropertyMapper, CommandMapper) {
    }

    private static IPropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler> PropertyMapper =
        new PropertyMapper<SegmentedButtonsControl, SegmentedButtonsHandler>(ViewMapper) {
            [nameof(SegmentedButtonsControl.SelectedIndices)] = MapSelectedIndices,
            [nameof(SegmentedButtonsControl.AllowsMultipleSelection)] = MapAllowsMultipleSelection,
            [nameof(SegmentedButtonsControl.Buttons)] = MapButtons,
        };

    private static void MapButtons(SegmentedButtonsHandler handler, SegmentedButtonsControl control) {
        handler.Wrapper.Buttons = control.Buttons.ToArray();
    }

    private static void MapAllowsMultipleSelection(SegmentedButtonsHandler handler, SegmentedButtonsControl control) {
        handler.Wrapper.AllowsMultipleSelection = control.AllowsMultipleSelection;
    }

    private static void MapSelectedIndices(SegmentedButtonsHandler handler, SegmentedButtonsControl control) {
        handler.Wrapper.SelectedIndices = control.SelectedIndices.ToNSNumbersArray();
    }

    public static CommandMapper<SegmentedButtonsControl, SegmentedButtonsHandler> CommandMapper = new(ViewCommandMapper) {
        [nameof(SegmentedButtonsControl.Buttons.CollectionChanged)] = MapButtonsCollectionChanged,
    };

    private static void MapButtonsCollectionChanged(SegmentedButtonsHandler handler, SegmentedButtonsControl control, object args) {
        handler.Wrapper.Buttons = control.Buttons.ToArray();
    }

    protected override UIView CreatePlatformView() {
        Wrapper = new SegmentedButtonsWrapper();
        return Wrapper.UiView;
    }
}