namespace CadastroDeEventos_;

public partial class TelaInicial : ContentPage
{
	public TelaInicial()
	{
		InitializeComponent();
	}

    private async void btnAvancar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TelaCadastro());
    }
}