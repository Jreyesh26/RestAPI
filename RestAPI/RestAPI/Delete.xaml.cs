using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Delete : ContentPage
    {
        public Delete()
        {
            InitializeComponent();
        }

        private async void Borrar(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var result =  await client.DeleteAsync(String.Concat("http://ec2-18-231-108-168.sa-east-1.compute.amazonaws.com/", ID.Text));

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Borrado!", "El empleado a sido Borrado", "Aceptar");
            }
        }
    }
}