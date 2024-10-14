# SwiftUI_To_MAUI
How to use SwiftUI components as an iOS implementation for MAUI controls.

### How to build
In MacOS terminal

Go to SwiftUI_To_MAUI/Scripts directory then run build.sh script

```zsh
./build.sh
```

The script builds step by step:
 - SwiftUI framework
 - SwiftUI to MAUI binding library
 - MAUI controls library
 
So, now you can play with MAUI_App for testing, or create your own MAUI app with reference to MAUI_Library.dll and SwiftUI_MAUI_Bindings.dll.

Also, you can set parameters to build partially.

 * **-all** - builds all parts (like without parameters)
 * **-ios** or **--ios** - builds Swift framework
 * **-b** or **--bindings** - builds Bindings library
 * **-m** or **--maui** - builds MAUI library
 * **-h** or **--help** - shows help
 
Example:

Run to build Swift framework and Bindings library
```zsh
./build.sh -ios -b
```
