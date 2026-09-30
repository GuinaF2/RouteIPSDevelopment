namespace RouteDevelopment
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("PageTutorial", typeof(PageTutorial));

        }
    }
}
