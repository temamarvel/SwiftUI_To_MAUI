//
//  SegmentedButtonsWrapper.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 07.12.2022.
//

import Foundation
import SwiftUI

@objc public class SegmentedButtonsWrapper : NSObject, UIViewHost, UIKitWrapper {
    typealias SwiftUIView = SegmentedButtonsView
    typealias Controller = HostingController
    
    var swiftUIView: SegmentedButtonsView?
    var hostingController: HostingController<SegmentedButtonsView>?
    
    @objc public var uiView: UIView? {
        hostingController?.view
    }
    
    @objc @Published public var buttons: [ButtonDescription] = [ButtonDescription(index: 0, text: "One"), ButtonDescription(index: 1, text: "Two"), ButtonDescription(index: 2, text: "Three")]
    
    public var selectedIndices: [Int] { buttons.filter { description in description.isSelected == true }.map { $0.index } }
    
    required public override init(){
        super.init()
        createSwiftUIView()
    }
    
    func createSwiftUIView() {
        swiftUIView = SegmentedButtonsView(wrapper: self)
        createController(view: swiftUIView!)
    }
}
