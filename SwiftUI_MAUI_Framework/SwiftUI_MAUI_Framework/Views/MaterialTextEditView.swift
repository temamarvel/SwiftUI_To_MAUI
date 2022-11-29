//
//  MaterialTextEditView.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 29.11.2022.
//

import SwiftUI

struct MaterialTextEditView: View {
    @ObservedObject var wrapper: MaterialTextEditWrapper
    
    var body: some View {
        HStack{
            if let icon = wrapper.leadingIcon {
                Image(uiImage: icon)
            }
        }
    }
}


struct MaterialTextEditView_Previews: PreviewProvider {
    static var wrapper = MaterialTextEditWrapper()
    
    static var previews: some View {
        MaterialTextEditView(wrapper: wrapper)
    }
}
