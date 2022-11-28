#!/bin/zsh
timestamp() {
  date +"%T" # current time
}

print_green() {
  printf "\e[32m$1\e[m"
}

print_yellow() {
  printf "\e[33m$1\e[m"
}

print_help(){
  echo "Run ./build without parameters to build ALL PARTS (Swift framework, Binding library, MAUI library). Default behavior."
  echo "\nParameters:"
  echo "-all or --all\t\t - builds all parts (like without parameters)"
  echo "-ios or --ios\t\t - builds Swift framework"
  echo "-b or --bindings\t - builds Bindings library"
  echo "-m or --maui\t\t - builds MAUI library"
  echo "-h or --help\t\t - shows help"  
  echo "\nExample:"
  echo "./build.sh -ios -b\ -- builds Swift framework and Bindings library"
  echo "\nSource on GitHub:"
  echo "https://github.com/temamarvel/SwiftUI_To_MAUI"
}

print_green "SCRIPT STARTED at $(timestamp)"

#SETUP BUILD CONFIGURATION

#parameters list
all=true
ios=false
bindings=false
maui=false

#read parameters one by one
while [[ "$#" -gt 0 ]]
do
case $1 in
    -all|--all)
      all=true;;
    -ios|--ios)
      all=false
      ios=true;;
    -b|--bindings)
      all=false
      bindings=true;;
    -m|--maui)
      all=false
      maui=true;;
    -h|--help)
      print_help
      all=false;;      
    *)
      echo "Unknown parameter passed: $1"
      print_help
      exit 1;;
esac
shift
done

if [[ "$all" = true ]]; then
  ios=true
  bindings=true
  maui=true
fi

if [[ "$ios" = false ]] && [[ "$bindings" = false ]] && [[ "$maui" = false ]]; then
  exit 0
fi

print_yellow "\nBUILD TARGETS:\n"
print_yellow "SwiftUI_MAUI_Framework = $ios\n"
print_yellow "SwiftUI_MAUI_Bindings = $bindings\n"
print_yellow "MAUI_Library = $maui\n"

#GO TO ROOT DIRECTORY

cd ..

#CLEAN

print_yellow "\n[Clean directories]\n"

if [[ "$ios" = true ]]; then
  printf "Clean XCFrameworks...\n"
  rm XCFrameworks/ApiDefinitions.cs
  rm -r XCFrameworks/*.xcarchive
  rm -r XCFrameworks/SwiftUI_MAUI_Framework.xcframework

  printf "Clean ApiDefinitions.cs file...\n"
  rm SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/ApiDefinitions.cs
fi

if [[ "$bindings" = true ]]; then
  printf "Clean SwiftUI_MAUI_Bindings...\n"
  rm -r SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/bin
  rm -r SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/obj
fi

if [[ "$maui" = true ]]; then
  printf "Clean MAUI_Library...\n"
  rm -r MAUI_Library/MAUI_Library/bin
  rm -r MAUI_Library/MAUI_Library/obj
fi

#CREATE XCFramework

if [[ "$ios" = true ]]
then
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
  
  cd ..

  #GENERATE ApiDefinitions  

  print_yellow "\n[Generate ApiDefinitions.cs file]\n"

  sharpie bind \
   -sdk iphoneos \
   -output XCFrameworks/ \
   -namespace SwiftUI_MAUI_Framework \
   -framework XCFrameworks/SwiftUI_MAUI_Framework.xcframework/ios-arm64/SwiftUI_MAUI_Framework.framework

  #print_yellow "\n[Fix protocol/intarface names in ApiDefinitions.cs file]\n"

  #python3 protocolsToInterface.py

  cp XCFrameworks/ApiDefinitions.cs SwiftUI_MAUI_Bindings/SwiftUI_MAUI_Bindings/
else
  print_yellow "\nBuild Swift framework skipped...\n"
fi

#BUILD Bindings library

if [[ "$bindings" = true ]]
then
  cd SwiftUI_MAUI_Bindings

  print_yellow "\n[Build bindings]\n"

  dotnet build --no-incremental

  cd ..
else
  print_yellow "\nBuild bindings skipped...\n"
fi

#BUILD MAUI library

if [[ "$maui" = true ]]
then
  cd MAUI_Library

  print_yellow "\n[Build MAUI library]\n"

  dotnet build --no-incremental

  cd ..
else
  print_yellow "\n[Build MAUI library skipped...]\n"
fi

print_green "\nSCRIPT FINISHED at $(timestamp)!\n"