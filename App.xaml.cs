using Microsoft.Extensions.DependencyInjection;

namespace RouteDevelopment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // opcional: não precisa definir MainPage se for criar a Window aqui
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Retorne a janela com a página inicial desejada
            return new Window(new AppShell());
            // Se usar Shell: return new Window(new AppShell());
        }
    }
}