namespace RouteDevelopment;

public partial class PontosDeInteresse2 : ContentPage
{
    public PontosDeInteresse2()
    {
        InitializeComponent();
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}