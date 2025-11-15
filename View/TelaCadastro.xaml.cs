using System;
using MauiAppHotel.Models;

namespace CadastroDeEventos_
{
    public partial class TelaCadastro : ContentPage
    {
        private Eventos evento;

        public TelaCadastro(Eventos eventoModel)
        {
            InitializeComponent();

            evento = eventoModel ?? throw new ArgumentNullException(nameof(eventoModel));
            BindingContext = evento;
        }

        private async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

