//
//  SpinEditWrapper.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 25.11.2022.
//

import Foundation
import SwiftUI

@objc public class SpinEditWrapper: NSObject, ObservableObject {
    var swiftUIView: SpinEditView?
    var hostingController: UIHostingController<SpinEditView>?
    
    @objc @Published public var value: Decimal = 0 {
        didSet {
            guard let handler = onValueChanged else { return }
            handler(value)
        }
    }
    @objc @Published public var interval: Decimal = 1 {
        didSet {
            guard let handler = onIntervalChanged else { return }
            handler(value)
        }
    }
    @objc public var onValueChanged : ((Decimal) -> Void)?
    @objc public var onIntervalChanged : ((Decimal) -> Void)?
    
    @objc public var uiView: UIView? { hostingController?.view }
    
    public override init() {
        super.init()
        
        swiftUIView = SpinEditView(wrapper: self)
        guard let rootView = swiftUIView else { return }
        hostingController = UIHostingController(rootView: rootView)
    }
}
