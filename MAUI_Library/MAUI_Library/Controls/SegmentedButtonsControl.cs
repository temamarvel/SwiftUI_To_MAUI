using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using SwiftUI_MAUI_Framework;

namespace MAUI_Library;

public class SegmentedButtonsControl : View {
    public static readonly BindableProperty SelectedIndicesProperty = BindableProperty.Create(nameof(SelectedIndices), typeof(List<int>), typeof(SegmentedButtonsControl), new List<int>());
    public static readonly BindableProperty AllowsMultipleSelectionProperty = BindableProperty.Create(nameof(AllowsMultipleSelection), typeof(bool), typeof(SegmentedButtonsControl), default);
    public static readonly BindableProperty ButtonsProperty = BindableProperty.Create(nameof(Buttons), typeof(ObservableCollection<ButtonDescription>), typeof(SegmentedButtonsControl), new ObservableCollection<ButtonDescription>());

    public SegmentedButtonsControl() {
        Buttons.CollectionChanged += ButtonsOnCollectionChanged;
    }

    private void ButtonsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args) {
        Handler?.Invoke(nameof(SegmentedButtonsControl.Buttons.CollectionChanged), args);
    }

    public List<int> SelectedIndices {
        get => (List<int>)GetValue(SelectedIndicesProperty);
        set => SetValue(SelectedIndicesProperty, value);
    }
    
    public bool AllowsMultipleSelection {
        get => (bool)GetValue(AllowsMultipleSelectionProperty);
        set => SetValue(AllowsMultipleSelectionProperty, value);
    }
    
    public ObservableCollection<ButtonDescription> Buttons {
        get => (ObservableCollection<ButtonDescription>)GetValue(ButtonsProperty);
        set => SetValue(ButtonsProperty, value);
    }
}