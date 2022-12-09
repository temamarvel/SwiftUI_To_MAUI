using Foundation;
using Microsoft.Maui.Graphics.Platform;
using UIKit;

public static class UIColorExtensions {
    public static UIColor ToUIColor(this Brush brush) {
        var paint = (Paint)brush;
        return paint.ToColor().AsUIColor();
    }
}

public static class CollectionsExtensions {
    public static NSNumber[] ToNSNumbersArray(this List<int> list) {
        NSNumber[] platformArray = new NSNumber[list.Count];
        for (int i = 0; i < list.Count; i++) {
            platformArray[i] = list[i];
        }

        return platformArray;
    }
}