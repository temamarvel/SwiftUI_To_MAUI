using Microsoft.Maui.Graphics.Platform;
using UIKit;

public static class UIColorExtensions {
    public static UIColor ToUIColor(this Brush brush) {
        var paint = (Paint)brush;
        return paint.ToColor().AsUIColor();
    }
}