#!/bin/zsh

print_green() {
  printf "\e[32m$1\e[m"
}

print_yellow() {
  printf "\e[33m$1\e[m"
}

#GO TO ROOT DIRECTORY
cd ..

#CLEAN

print_yellow "\n[Clean directories]\n"

print_yellow "Clean XCFrameworks...\n"
rm XCFrameworks/ApiDefinitions.cs
rm -r XCFrameworks/*.xcarchive
rm -r XCFrameworks/SwiftUI_MAUI_Framework.xcframework

print_yellow "Clean SwiftUI_MAUI_Bindings...\n"
rm SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/ApiDefinitions.cs
rm -r SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/bin
rm -r SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/obj

print_yellow "Clean MAUI_Library...\n"
rm -r MAUI_Library/MAUI_Library/bin
rm -r MAUI_Library/MAUI_Library/obj

#CREATE XCFramework

cd SwiftUI_MAUI_Framework

print_yellow "\n[Archive build]\n"

xcodebuild archive \
 -scheme SwiftUI_MAUI_Framework \
 -archivePath ../XCFrameworks/SwiftMaui-ios.xcarchive \
 -sdk iphoneos \
 SKIP_INSTALL=NO

xcodebuild archive \
 -scheme SwiftUI_MAUI_Framework \
 -archivePath ../XCFrameworks/SwiftMaui-sim.xcarchive \
 -sdk iphonesimulator \
 SKIP_INSTALL=NO

print_yellow "\n[Create xcframework]\n"

xcodebuild -create-xcframework \
 -framework ../XCFrameworks/SwiftMaui-sim.xcarchive/Products/Library/Frameworks/SwiftUI_MAUI_Framework.framework \
 -framework ../XCFrameworks/SwiftMaui-ios.xcarchive/Products/Library/Frameworks/SwiftUI_MAUI_Framework.framework \
 -output ../XCFrameworks/SwiftUI_MAUI_Framework.xcframework

#GENERATE ApiDefinitions

cd ..

print_yellow "\n[Generate ApiDefinitions.cs file]\n"

sharpie bind \
 -sdk iphoneos \
 -output XCFrameworks/ \
 -namespace SwiftUI_MAUI_Framework \
 -framework XCFrameworks/SwiftUI_MAUI_Framework.xcframework/ios-arm64/SwiftUI_MAUI_Framework.framework

#print_yellow "\n[Fix protocol/intarface names in ApiDefinitions.cs file]\n"

#python3 protocolsToInterface.py

cp XCFrameworks/ApiDefinitions.cs SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/

cd SwiftUI_MAUI_Bindings

#BUILD Bindings library

print_yellow "\n[Build bindings]\n"

dotnet build --no-incremental

#BUILD MAUI library

cd -

cd MAUI_Library

print_yellow "\n[Build MAUI library]\n"

dotnet build --no-incremental

print_green "DONE!"