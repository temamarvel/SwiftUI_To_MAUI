namespace MAUI_Library;

public class SpinEditControl : View {
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(decimal), typeof(SpinEditControl), default(decimal));
    public static readonly BindableProperty IntervalProperty = BindableProperty.Create(
        nameof(Interval), typeof(decimal), typeof(SpinEditControl), 1);
    
    public decimal Value {
        get => (decimal)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
    public decimal Interval {
        get => (decimal)GetValue(IntervalProperty);
        set => SetValue(IntervalProperty, value);
    }
}