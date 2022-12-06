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
    @objc public var borderThickness: CGFloat = 1
    @objc public var padding = UIEdgeInsets(top: 10, left: 10, bottom: 10, right: 10)
    
    @objc @Published public var text = "default text"
    @objc @Published public var borderColor: UIColor = UIColor(Color.secondary)
    @objc @Published public var focusedBorderColor: UIColor = UIColor(Color.blue)
    
    required public override init(){
        super.init()
        createSwiftUIView()
    }
    
    func createSwiftUIView() {
        swiftUIView = MaterialTextEditView(wrapper: self)
        createController(view: swiftUIView!)
    }
}
