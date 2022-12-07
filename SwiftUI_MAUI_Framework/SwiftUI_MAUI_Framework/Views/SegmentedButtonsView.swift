//
//  SegmentedButtonsView.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 07.12.2022.
//

import SwiftUI

@objc public class ButtonDescription : NSObject, Identifiable, ObservableObject {
    @objc public var id : Int { return index }
    
    let index: Int
    public let text: String
    @Published public var isSelected = false
    
    init(index: Int, text: String) {
        self.index = index
        self.text = text
    }
}

struct SegmentedButtonsView: View {
    @ObservedObject var wrapper: SegmentedButtonsWrapper
    
    var body: some View {
        VStack{
            HStack{
                ForEach($wrapper.buttons){ $button in
                    Toggle(button.text, isOn: $button.isSelected).toggleStyle(.button)
                }
            }.background(.orange).clipShape(Capsule())
            
            ForEach(wrapper.buttons){ button in
                Text(String(button.isSelected)).background(.green)
            }
            
            Text(wrapper.selectedIndices.description)
            
            Button("Click me", action: {
                //wrapper.buttons.append(ButtonDescription(index: 3, text: "Four"))
                wrapper.buttons[0].isSelected = true
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
