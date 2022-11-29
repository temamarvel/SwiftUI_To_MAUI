//
//  Protocols.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 29.11.2022.
//

import Foundation
import UIKit
import SwiftUI

@objc public protocol UIViewHost{
    var uiView: UIView? { get }
}

protocol UIKitWrapper : NSObject, ObservableObject {
    associatedtype SwiftUIView where SwiftUIView: View
    associatedtype Controller where Controller : HostingController<SwiftUIView>
    
    var swiftUIView : SwiftUIView? { get set }
    var hostingController : Controller? { get set}
    
    init()
    
    //MARK: the method can't have default implementation in UIKitWrapper extension
    //It must reference view-model object, which conforms more than one protocol UIKitWrapper
    //So, you must implement it by yourself
    func createSwiftUIView() -> Void
}

extension UIKitWrapper {
    func createController(view: SwiftUIView){
        hostingController = Controller(rootView: view)
    }
}
