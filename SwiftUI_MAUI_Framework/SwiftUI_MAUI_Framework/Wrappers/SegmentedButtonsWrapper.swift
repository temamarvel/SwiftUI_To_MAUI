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
    
    @objc @Published var buttons: [ButtonDescription] = [ButtonDescription(text: "One"), ButtonDescription(text: "Two"), ButtonDescription(text: "Three")] {
        willSet(newButtons){
            if !allowsMultipleSelection {
                applySingleSelection(buttons: newButtons)
            }
            newButtons.forEach{ button in button.cachedIsSelected = button.isSelected }
        }
    }
    
    @objc @Published public var allowsMultipleSelection = false
    
    @objc public var selectedIndices: [Int] {
        set(newIndices){
            buttons = buttons.enumerated().map { (index, element) in
                if newIndices.contains(index) {
                    element.isSelected = true
                }
                return element
            }
        }
        get{
            buttons.enumerated().compactMap{ (index, element) in
                element.isSelected ? index : nil
            }
        }
    }
    
    @objc public var selectedButtons: [ButtonDescription] { buttons.filter{ description in description.isSelected == true } }
    
    required public override init(){
        super.init()
        createSwiftUIView()
    }
    
    func createSwiftUIView() {
        swiftUIView = SegmentedButtonsView(wrapper: self)
        createController(view: swiftUIView!)
    }
    
    func applySingleSelection(buttons: [ButtonDescription]) {
        var hasOneSelected = false
        
        buttons.forEach{ newButton in
            if !(newButton.isSelected && !newButton.cachedIsSelected) || hasOneSelected{
                newButton.isSelected = false
            } else if !hasOneSelected {
                hasOneSelected = true
            }
        }
    }
}
