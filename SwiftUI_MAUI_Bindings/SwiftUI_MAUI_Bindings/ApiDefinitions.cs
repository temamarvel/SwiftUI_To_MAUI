using System;
using Foundation;
using ObjCRuntime;
using SwiftUI_MAUI_Framework;
using UIKit;

namespace SwiftUI_MAUI_Framework
{
	// @interface ButtonDescription : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework17ButtonDescription")]
	[DisableDefaultCtor]
	interface ButtonDescription
	{
	}

	// @interface HelloWorldWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework17HelloWorldWrapper")]
	interface HelloWorldWrapper
	{
		// @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }
	}

	// @protocol UIViewHost
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol (Name = "_TtP22SwiftUI_MAUI_Framework10UIViewHost_")]
	interface UIViewHost
	{
		// @required @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[Abstract]
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }
	}

	// @interface MaterialTextEditWrapper : NSObject <UIViewHost>
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework23MaterialTextEditWrapper")]
	interface MaterialTextEditWrapper : UIViewHost
	{
		// @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }

		// @property (nonatomic, strong) UIImage * _Nullable leadingIcon;
		[NullAllowed, Export ("leadingIcon", ArgumentSemantic.Strong)]
		UIImage LeadingIcon { get; set; }

		// @property (nonatomic) CGFloat borderThickness;
		[Export ("borderThickness")]
		nfloat BorderThickness { get; set; }

		// @property (nonatomic) UIEdgeInsets padding;
		[Export ("padding", ArgumentSemantic.Assign)]
		UIEdgeInsets Padding { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull focusedBorderColor;
		[Export ("focusedBorderColor", ArgumentSemantic.Strong)]
		UIColor FocusedBorderColor { get; set; }
	}

	// @interface SegmentedButtonsWrapper : NSObject <UIViewHost>
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework23SegmentedButtonsWrapper")]
	interface SegmentedButtonsWrapper : UIViewHost
	{
		// @property (readonly, nonatomic, strong) UIView * _Nullable uiView;
		[NullAllowed, Export ("uiView", ArgumentSemantic.Strong)]
		UIView UiView { get; }

		// @property (copy, nonatomic) NSArray<ButtonDescription *> * _Nonnull buttons;
		[Export ("buttons", ArgumentSemantic.Copy)]
		ButtonDescription[] Buttons { get; set; }

		// @property (nonatomic) BOOL allowsMultipleSelection;
		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull selectedIndices;
		[Export ("selectedIndices", ArgumentSemantic.Copy)]
		NSNumber[] SelectedIndices { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<ButtonDescription *> * _Nonnull selectedButtons;
		[Export ("selectedButtons", ArgumentSemantic.Copy)]
		ButtonDescription[] SelectedButtons { get; }
	}

	// @interface SpinEditWrapper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC22SwiftUI_MAUI_Framework15SpinEditWrapper")]
	interface SpinEditWrapper
	{
		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull focusedBorderColor;
		[Export ("focusedBorderColor", ArgumentSemantic.Strong)]
		UIColor FocusedBorderColor { get; set; }

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
