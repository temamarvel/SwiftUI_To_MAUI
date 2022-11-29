using Android.Widget;
using Microsoft.Maui.Handlers;
using View = Android.Views.View;

namespace MAUI_Library;

//Implement handler for Android platform here
public partial class MaterialTextEditHandler: ViewHandler<MaterialTextEditControl, Android.Views.View> {
    public MaterialTextEditHandler() : base(PropertyMapper) { }

    public static IPropertyMapper<MaterialTextEditControl, MaterialTextEditHandler> PropertyMapper =
        new PropertyMapper<MaterialTextEditControl, MaterialTextEditHandler>(ViewHandler.ViewMapper) { };
    
    protected override Android.Views.View CreatePlatformView() {
        //it is just a mock view
        //create something real for a correct implementation
        return new View(null);
    }
}