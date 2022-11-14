using Exercise2_2.Models;
using Exercise2_2.Views;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise2_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        private String encriptado;
        public Principal()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Stream img = await firmaa.GetImageStreamAsync(SignatureImageFormat.Png);
            var memmo = (MemoryStream)img;//casteando a un memory
            byte[] data = memmo.ToArray();//pasando a binarydata
            encriptado = Convert.ToBase64String(data);//por ultimo base64
            if (txtnombree.Text.Length >= 0 || txtdescrip.Text.Length >= 0)
            {
                await DisplayAlert("AVISO", "LLENA TODOS LOS DATOS", "OK");
            }
            else
            {
                var firma = new Firma
                {
                    imageencripted = encriptado,
                    nombre = txtnombree.Text,
                    desc = txtdescrip.Text
                };
                int respuesta = await App.BaseDatos.guardaFirma(firma);
                if (respuesta == 1){await DisplayAlert("LISTO", "FIRMA GUARDADA", "OK");}
                else{await DisplayAlert("ERROR", "PORFAVOR,  VUELVELO A INTENTAR", "OK");}
            }
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            firmaa.Clear();
            txtdescrip.Text = "";
            txtnombree.Text = "";
            await DisplayAlert("LISTOS", "DATOS ELIMINADOS", "OK");
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaDeFirmas());
        }
    }
}