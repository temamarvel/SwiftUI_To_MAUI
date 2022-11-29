//
//  MaterialTextEditWrapper.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 29.11.2022.
//

import Foundation
import SwiftUI

@objc public class MaterialTextEditWrapper: NSObject, UIViewHost, UIKitWrapper {
    typealias SwiftUIView = MaterialTextEditView
    typealias Controller = HostingController<MaterialTextEditView>
    
    var swiftUIView: MaterialTextEditView?
    var hostingController: HostingController<MaterialTextEditView>?
    @objc public var uiView: UIView? {
        hostingController?.view
    }
    @objc public var leadingIcon: UIImage?
    
    required public override init(){
        super.init()
        createSwiftUIView()
    }
    
    func createSwiftUIView() {
        swiftUIView = MaterialTextEditView(wrapper: self)
        createController(view: swiftUIView!)
    }
}
