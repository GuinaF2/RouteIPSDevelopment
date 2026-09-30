namespace RouteDevelopment
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("PageTutorial", typeof(PageTutorial));
            Routing.RegisterRoute("PageTutorial2", typeof(PageTutorial2));
            Routing.RegisterRoute("PontoInteressePage", typeof(PontoInteressePage));
            Routing.RegisterRoute("PontosDeInteresse2", typeof(PontosDeInteresse2));

        }
    }
}
