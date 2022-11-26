//
//  SpinEditView.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 25.11.2022.
//

import SwiftUI

struct SpinEditView: View {
    @ObservedObject var wrapper: SpinEditWrapper
    
    @FocusState private var isFocused : Bool
    
    var body: some View {
        VStack{
            Button {wrapper.value += wrapper.interval} label: {
                Image(systemName: "chevron.up")
                    .resizable()
                    .frame(width: 40, height: 20)
            }
            
            TextField("Number", value: $wrapper.value, format: .number)
                .focused($isFocused)
                .multilineTextAlignment(.center)
                .textFieldStyle(.roundedBorder)
                .background(){
                    RoundedRectangle(cornerRadius: 4)
                        .stroke(isFocused ? Color(wrapper.focusedBorderColor) : Color(wrapper.borderColor), lineWidth: 2)
                        .animation(.easeInOut, value: isFocused)
                }
            
            Button {wrapper.value -= wrapper.interval} label: {
                Image(systemName: "chevron.down")
                    .resizable()
                    .frame(width: 40, height: 20)
            }
        }
    }
}


struct SpinEditView_Previews: PreviewProvider {
    static var wrapper = SpinEditWrapper()
    
    static var previews: some View {
        SpinEditView(wrapper: wrapper)
    }
}
