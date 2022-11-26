namespace MAUI_Library;

public class SpinEditControl : View {
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(decimal), typeof(SpinEditControl), default(decimal));
    public static readonly BindableProperty IntervalProperty = BindableProperty.Create(nameof(Interval), typeof(decimal), typeof(SpinEditControl), 1m);
    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Brush), typeof(SpinEditControl), Brush.LightGray);
    public static readonly BindableProperty FocusedBorderColorProperty = BindableProperty.Create(nameof(FocusedBorderColor), typeof(Brush), typeof(SpinEditControl), Brush.Blue);
    
    public decimal Value {
        get => (decimal)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public decimal Interval {
        get => (decimal)GetValue(IntervalProperty);
        set => SetValue(IntervalProperty, value);
    }
    public Brush BorderColor {
        get => (Brush)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
    public Brush FocusedBorderColor {
        get => (Brush)GetValue(FocusedBorderColorProperty);
        set => SetValue(FocusedBorderColorProperty, value);
    }
}