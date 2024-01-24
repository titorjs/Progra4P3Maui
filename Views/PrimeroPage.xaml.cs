using ExamenProgreso3_Disenio.Models;
using ExamenProgreso3_Disenio.Services;
using System.Collections.ObjectModel;

namespace ExamenProgreso3_Disenio.Views;

public partial class PrimeroPage : ContentPage
{
    private readonly ApiService _APIService;
    public List<Tarea> Tareas { get; set; }

    public PrimeroPage(ApiService apiService)
	{
		InitializeComponent();
        _APIService = apiService;
	}

    private void OnClickNuevaTarea(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NuevaTareaPage(_APIService));
    }

    private async void OnClickMostrarLista(object sender, EventArgs e)
    {
        string Nombre = nombre.Text, Estado = estado.Text;
        if(string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Estado))
        {
            await DisplayAlert("Error", "Llene todos los campos", "Ok");
            return;
        }
        try
        {
            List<Tarea> listaTarea = await _APIService.Find(Nombre,Estado);
            
            if(listaTarea == null)
            {
                TareasList.IsVisible = false;
                await DisplayAlert("Error", "No Existe una lista con esos valores", "Ok");
            }
            else
            {
                Tareas = listaTarea;
                TareasList.IsVisible = true;
                TareasList.ItemsSource = listaTarea;
                await DisplayAlert("Exito", "Lista actualizada", "Ok");
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Error", "Error en el sistema con API", "Ok");
        }
        
    }
}