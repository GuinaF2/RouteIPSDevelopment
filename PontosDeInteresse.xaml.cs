namespace RouteDevelopment;

public partial class PontoInteressePage : ContentPage
{
    public PontoInteressePage()
    {
        InitializeComponent();
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
