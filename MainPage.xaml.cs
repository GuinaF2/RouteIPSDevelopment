namespace RouteDevelopment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Biblioteca_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PontoInteressePage");
        }
        private async void BanheiroFeminino_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PontosDeInteresse2");
        }
    }
}
