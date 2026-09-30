namespace RouteDevelopment;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}