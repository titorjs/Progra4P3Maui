using ExamenProgreso3_Disenio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgreso3_Disenio.Services
{
    public class ApiService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public ApiService()
        {
            _baseUrl = "https://bb73-2a09-bac5-3095-aa-00-11-19a.ngrok-free.app/api/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        public async Task<List<Tarea>> GetAll()
        {
            var respuesta = await _httpClient.GetFromJsonAsync<List<Tarea>>(_baseUrl + "Tarea");
            if (respuesta == null)
            {
                return new List<Tarea>();
            }
            return respuesta;
        }

        public async Task<List<Tarea>> Find(string nombre, string estado)
        {
            var respuesta = await _httpClient.GetFromJsonAsync<List<Tarea>>(_baseUrl + "Tarea/buscar/" + nombre + "/" + estado);
            if (respuesta == null)
            {
                return new List<Tarea>();
            }
            return respuesta;
        }
        public async Task<bool> Add(Tarea nueva)
        {
            var respueta = _httpClient.PostAsJsonAsync<Tarea>(_baseUrl + "Tarea", nueva);
            return respueta != null;
        }
    }
}
