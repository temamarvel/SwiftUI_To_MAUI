using System.Collections;

namespace MAUI_Library;

public class SegmentedButtonsControl : View {
    public static readonly BindableProperty SelectedIndicesProperty = BindableProperty.Create(nameof(SelectedIndices), typeof(List<int>), typeof(SegmentedButtonsControl), new List<int>());
    public static readonly BindableProperty AllowsMultipleSelectionProperty = BindableProperty.Create(nameof(AllowsMultipleSelection), typeof(bool), typeof(SegmentedButtonsControl), default);
    
    public List<int> SelectedIndices {
        get => (List<int>)GetValue(SelectedIndicesProperty);
        set => SetValue(SelectedIndicesProperty, value);
    }
    
    public bool AllowsMultipleSelection {
        get => (bool)GetValue(AllowsMultipleSelectionProperty);
        set => SetValue(AllowsMultipleSelectionProperty, value);
    }
}