using SwiftUI_MAUI_Framework;

namespace MAUI_App;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e) {
        segmented.SelectedIndices = new List<int>() { 1 };
    }

    private void Switch_OnToggled(object sender, ToggledEventArgs e) {
        segmented.AllowsMultipleSelection = !segmented.AllowsMultipleSelection;
    }

    private void Button_OnClicked2(object sender, EventArgs e) {
        segmented.Buttons.Add(new ButtonDescription("TestBtn"));
    }

    private void Button_OnClicked3(object sender, EventArgs e) {
        stackLayout.Add(new Button(){Text = "Added button"});
    }
}