using Foundation;
using ObjCRuntime;
using UIKit;

namespace SwiftUI_MAUI_Framework
{
	// @interface HelloWorldWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework17HelloWorldWrapper")]
	interface HelloWorldWrapper
	{
		// @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }
	}
}
