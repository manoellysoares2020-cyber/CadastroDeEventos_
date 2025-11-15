using System;
using MauiAppHotel.Models; 
using Microsoft.Maui.Controls;

namespace CadastroDeEventos_
{
    public partial class TelaInicial : ContentPage

    {
      
        private Eventos eventos;

        public TelaInicial()
        {
            InitializeComponent();

            eventos = new Eventos
            {
                CheckIn = DateTime.Now.Date,
                CheckOut = DateTime.Now.Date.AddDays(1),
                Participantes = 1,
                CustoPorParticipante = 100.0
            };

            BindingContext = eventos;

            dtpCheckin.MinimumDate = DateTime.Now.Date;
            dtpCheckIn.MaximumDate = DateTime.Now.Date.AddMonths(12);

            dtpCheckOut.MinimumDate = eventos.CheckIn.AddDays(1);
            dtpCheckOut.MaximumDate = eventos.CheckIn.AddMonths(6);

            // Quando o usuário muda o Check-in
            dtpCheckIn.DateSelected += (s, e) =>
            {
                eventos.CheckIn = e.NewDate.Date;

                dtpCheckOut.MinimumDate = eventos.CheckIn.AddDays(1);
                dtpCheckOut.MaximumDate = eventos.CheckIn.AddMonths(6);

                // Garante que o Check-out nunca fique antes do mínimo
                if (dtpCheckOut.Date < dtpCheckOut.MinimumDate)
                    dtpCheckOut.Date = dtpCheckOut.MinimumDate;
            };

            // Quando o usuário muda o Check-out
            dtpCheckOut.DateSelected += (s, e) =>
            {
                eventos.CheckOut = e.NewDate.Date;
            };
        }
  
        private async void BtnAvancar_Clicked(object sender, EventArgs e)
        {
            // validações básicas
            if (string.IsNullOrWhiteSpace(eventos.Nome))
            {
                await DisplayAlert("Atenção", "Digite o nome do evento.", "OK");
                return;
            }

            if (eventos.CheckOut <= eventos.CheckIn)
            {
                await DisplayAlert("Atenção", "Check-out deve ser posterior ao check-in.", "OK");
                return;
            }

            
            await Navigation.PushAsync(new TelaCadastro(eventos));
        }
    }
}

