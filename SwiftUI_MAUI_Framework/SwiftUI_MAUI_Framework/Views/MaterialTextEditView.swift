//
//  MaterialTextEditView.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 29.11.2022.
//

import SwiftUI

struct RoundedBorder: Shape {
    let radius = 10.0
    //@Binding var gap : CGFloat
    
    func path(in rect: CGRect) -> Path {
        var path = Path()
        
        //path.move(to: CGPoint(x: gap+radius, y: 0))
        // MARK: do gap for label
        path.move(to: CGPoint(x: radius, y: 0))
        path.addLine(to: CGPoint(x: rect.width - radius, y: 0))
        path.addArc(center: CGPoint(x: rect.width - radius, y: radius),
                    radius: radius,
                    startAngle: .degrees(270),
                    endAngle: .degrees(0),
                    clockwise: false)
        path.addLine(to: CGPoint(x: rect.width, y: rect.height - radius))
        path.addArc(center: CGPoint(x: rect.width - radius, y: rect.height - radius),
                    radius: radius,
                    startAngle: .degrees(0),
                    endAngle: .degrees(90),
                    clockwise: false)
        path.addLine(to: CGPoint(x: radius, y: rect.height))
        path.addArc(center: CGPoint(x: radius, y: rect.height - radius),
                    radius: radius,
                    startAngle: .degrees(90),
                    endAngle: .degrees(180),
                    clockwise: false)
        path.addLine(to: CGPoint(x: 0, y: radius))
        path.addArc(center: CGPoint(x: radius, y: radius),
                    radius: radius,
                    startAngle: .degrees(180),
                    endAngle: .degrees(270),
                    clockwise: false)
        
        return path
    }
}

struct MaterialTextEditView: View {
    @ObservedObject var wrapper: MaterialTextEditWrapper
    
    @FocusState private var isFocused : Bool
    
    var body: some View {
        HStack{
            // MARK: remove it bofore final build
            Image(systemName: "person.crop.circle.fill")
            
            if let icon = wrapper.leadingIcon {
                Image(uiImage: icon)
            }
            
            TextField("", text: $wrapper.text)
                .focused($isFocused)
            
            Button { wrapper.text = "" } label: {
                Image(systemName: "x.circle.fill")
                    .foregroundColor(Color.secondary)
            }
        }
        .padding(EdgeInsets(top: wrapper.padding.top,
                            leading: wrapper.padding.left,
                            bottom: wrapper.padding.bottom,
                            trailing: wrapper.padding.right))
        .background(){
            GeometryReader{ geometry in
                RoundedBorder()
                    .stroke(isFocused ? Color(wrapper.focusedBorderColor) : Color(wrapper.borderColor), lineWidth: wrapper.borderThickness)
            }
        }
    }
}


struct MaterialTextEditView_Previews: PreviewProvider {
    static var wrapper = MaterialTextEditWrapper()
    
    static var previews: some View {
        MaterialTextEditView(wrapper: wrapper).padding()
    }
}
