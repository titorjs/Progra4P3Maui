using ExamenProgreso3_Disenio.Services;
using ExamenProgreso3_Disenio.Views;

namespace ExamenProgreso3_Disenio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ApiService apiService = new ApiService();
            MainPage = new PrimeroPage(apiService);
        }
    }
}