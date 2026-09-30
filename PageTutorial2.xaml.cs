namespace RouteDevelopment;

public partial class PageTutorial2 : ContentPage
{
    public PageTutorial2()
    {
        InitializeComponent();
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}
