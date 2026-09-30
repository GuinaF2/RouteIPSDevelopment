namespace RouteDevelopment;

public partial class PageTutorial : ContentPage
{
    public PageTutorial()
    {
        InitializeComponent();
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PageTutorial2");
    }
}
