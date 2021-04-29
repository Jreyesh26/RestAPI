using Newtonsoft.Json;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class borrar : ContentPage
    {
        public borrar()
        {
            InitializeComponent();
        }

        private async void Actualizar(object sender, EventArgs e)
        {
            employees compa = new employees()
            {
                id = int.Parse(ID.Text),
                name = nombre.Text,
                salary = Int32.Parse(salario.Text)
            };

            var json = JsonConvert.SerializeObject(compa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var result = await client.PutAsync(string.Concat("http://ec2-18-231-108-168.sa-east-1.compute.amazonaws.com/", ID.Text), content);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Actualizado!", "El empleado a sido Actualizado", "Aceptar");
            }
        }


    }
}