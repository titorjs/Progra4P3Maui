using ExamenProgreso3_Disenio.Models;
using ExamenProgreso3_Disenio.Services;

namespace ExamenProgreso3_Disenio.Views;

public partial class NuevaTareaPage : ContentPage
{
    private readonly ApiService _APIService;
    public NuevaTareaPage(ApiService apiService)
	{
		InitializeComponent();
		_APIService = apiService;
	}

    private async void OnClickGuardarTarea(object sender, EventArgs e)
    {
		string Nombre=nombre.Text,Estado=estado.Text, Tarea=tarea.Text;
		if(string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Estado) || string.IsNullOrEmpty(Tarea) )
		{
            await DisplayAlert("Error", "Llene todos los campos", "Ok");
            return;
        }
		try
		{
			Tarea o= new Tarea
			{
				Nombre = Nombre,
				Estado = Estado,
				Descripcion = Tarea
			};
			bool validar = await _APIService.Add(o);
			if(validar)
			{
                await DisplayAlert("exito", "tarea agregada", "Ok");
                await Navigation.PopModalAsync();

            }

        }
        catch(Exception ex)
		{
            await DisplayAlert("Error", "Error en el sistema con API", "Ok");
        }
		
		/*if(validacion api)
		 {
			await Navigation.PopModalAsync()
		 }*/
    }
}