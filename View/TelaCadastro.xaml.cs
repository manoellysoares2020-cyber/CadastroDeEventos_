using Microsoft.Maui.Controls;
namespace CadastroDeEventos_;

public partial class TelaCadastro : ContentPage

{
    App PropriedadesApp;

    public TelaCadastro()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Volta para a tela anterior
    }
}