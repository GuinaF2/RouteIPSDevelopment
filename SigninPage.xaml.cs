namespace RouteDevelopment;

public partial class SigninPage : ContentPage
{
    public SigninPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PageTutorial");

    }
}
