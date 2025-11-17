
using CadastroDeEventos_.Models;

namespace CadastroDeEventos_
{
    public partial class App : Application
    {
        // Lista de eventos — opcional
        public List<Eventos> lista_eventos = new List<Eventos>();

        public App()
        {
            InitializeComponent();

            // IMPORTANTE para usar Navigation.PushAsync
            MainPage = new NavigationPage(new TelaInicial());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}
