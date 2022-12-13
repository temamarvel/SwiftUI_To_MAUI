//
//  HostingController.swift
//  SwiftUI_MAUI_Framework
//
//  Created by Art Denisov on 29.11.2022.
//

import Foundation
import UIKit
import SwiftUI

//have to create the descendant of UIHostingController
//because it doesn't have public init(Content)
class HostingController<Content> : UIHostingController<Content> where Content : View {
    required override init(rootView: Content) {
        super.init(rootView: rootView)
    }
    
    override func viewDidLayoutSubviews() {
        super.viewDidLayoutSubviews()
        //have to fit size of UIView to size of SwiftUI view
        self.view.sizeToFit()
    }
    
    //it is required initializer
    //so that it must be here
    @MainActor required dynamic init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
}
