namespace MAUI_Library;

public class MaterialTextEditControl : View {
    public static readonly BindableProperty LeadingIconSourceProperty = BindableProperty.Create(nameof(LeadingIconSource), typeof(ImageSource), typeof(MaterialTextEditControl), default);
    
    public ImageSource LeadingIconSource {
        get => (ImageSource)GetValue(LeadingIconSourceProperty);
        set => SetValue(LeadingIconSourceProperty, value);
    }
}