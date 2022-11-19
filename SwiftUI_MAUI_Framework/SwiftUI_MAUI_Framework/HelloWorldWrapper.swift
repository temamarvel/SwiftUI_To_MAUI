//
//  HelloWorldWrapper.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 19.11.2022.
//

import Foundation
import SwiftUI

@objc public class HelloWorldWrapper: NSObject, ObservableObject {
    var swiftUIView: HelloWorldView?
    var hostingController: UIHostingController<HelloWorldView>?
    
    @objc public var uiView: UIView? { hostingController?.view }
    
    public override init() {
        super.init()
        
        swiftUIView = HelloWorldView()
        guard let rootView = swiftUIView else { return }
        hostingController = UIHostingController(rootView: rootView)
    }
}
