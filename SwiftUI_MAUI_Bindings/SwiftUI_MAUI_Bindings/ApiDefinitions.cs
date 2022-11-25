using System;
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

	// @interface SpinEditWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework15SpinEditWrapper")]
	interface SpinEditWrapper
	{
		// @property (nonatomic) NSDecimal value;
		[Export ("value", ArgumentSemantic.Assign)]
		NSDecimal Value { get; set; }

		// @property (nonatomic) NSDecimal interval;
		[Export ("interval", ArgumentSemantic.Assign)]
		NSDecimal Interval { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSDecimal) onValueChanged;
		[NullAllowed, Export ("onValueChanged", ArgumentSemantic.Copy)]
		Action<NSDecimal> OnValueChanged { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(NSDecimal) onIntervalChanged;
		[NullAllowed, Export ("onIntervalChanged", ArgumentSemantic.Copy)]
		Action<NSDecimal> OnIntervalChanged { get; set; }

		// @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }
	}
}
