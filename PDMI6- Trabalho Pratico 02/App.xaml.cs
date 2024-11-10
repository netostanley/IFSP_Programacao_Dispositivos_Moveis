namespace TPMaui2
{
    public partial class App : Application
    {
        public static Models.TarefaRepository TarefaRepo { get; private set; }

        public App()
        {
            InitializeComponent();
            TarefaRepo = new Models.TarefaRepository();

            MainPage = new NavigationPage(new Views.PaginaInicial());
        }
    }

}
