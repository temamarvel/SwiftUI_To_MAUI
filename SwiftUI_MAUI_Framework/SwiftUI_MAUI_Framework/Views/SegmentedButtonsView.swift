//
//  SegmentedButtonsView.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 07.12.2022.
//

import SwiftUI

@objc public class ButtonDescription : NSObject, Identifiable{
    public let id = UUID()
    public var text: String
    public var isSelected = false
    public var cachedIsSelected = false
    
    @objc public init(text: String) {
        self.text = text
    }
}

struct SegmentedButtonsView: View {
    @ObservedObject var wrapper: SegmentedButtonsWrapper
    
    var body: some View {
        VStack{
            HStack(spacing: 0){
                ForEach($wrapper.buttons){ $button in
                    HStack(spacing: 0){
                        Toggle(button.text, isOn: $button.isSelected)
                            .toggleStyle(.button)
                        
                        if wrapper.buttons.last != button {
                            Divider()
                        }
                    }
                    .fixedSize()
                }
            }
            .background(.orange)
            .clipShape(Capsule())
            
            // MARK: Tests elements
            ForEach(wrapper.buttons){ button in
                Text(String(button.isSelected)).background(.green)
            }
            
            Text(wrapper.selectedIndices.description)
            
            Button("Click me", action: {
                wrapper.buttons.append(ButtonDescription(text: "Four"))
                //wrapper.objectWillChange.send()
                wrapper.buttons[0].isSelected.toggle()
            })
            
            Button("Click me2", action: {
                wrapper.selectedIndices = [0,2]
            })
        }
    }
}

struct SegmentedButtonsView_Previews: PreviewProvider {
    static var wrapper = SegmentedButtonsWrapper()
    
    static var previews: some View {
        SegmentedButtonsView(wrapper: wrapper)
    }
}
