using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using RestAPI.Models;

namespace RestAPI
{
    public partial class MainPage : ContentPage
    {
        HttpClient client;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ObtenerListado(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://ec2-18-231-108-168.sa-east-1.compute.amazonaws.com/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<employees>>(content);

                MiLista.ItemsSource = resultado;
            }
        }

        private async void BuscarID(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscaId());
        }

        private async void Actualizar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new borrar());
        }

        private async void Borrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Delete());
        }
    }
}
