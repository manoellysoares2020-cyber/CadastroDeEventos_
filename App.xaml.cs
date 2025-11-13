using MauiAppHotel.Models;

namespace CadastroDeEventos_
{
    public partial class App : Application
    {
        public List<Eventos> lista_eventos = new List<Eventos>
        {
            new Eventos()
            {
            Descricao = "Suíte Super Luxo",
            ValorDiariaAdulto = 150.00,
            },

            new Eventos()
            {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 80.00,
            },

            new Eventos()
            {
            Descricao = "Suíte Single",
            ValorDiariaAdulto = 50.00,
            },

            new Eventos()
            {
            Descricao = "Suíte Crise",
            ValorDiariaAdulto = 25.00,
            }
        };
        public App()
        {
            InitializeComponent();

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