using Exercise2_2.Models;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Exercise2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDeFirmas : ContentPage
    {
        public ListaDeFirmas()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listadp.ItemsSource = await App.BaseDatos.GetListFirmas();
        }

        private async void listadp_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = (Firma)e.Item;
            bool answer = await DisplayAlert("Pregunta?", "Deseas guardar esta firma a tu almacenamiento", "SI", "NO");
            if (answer == true)
            {
                try
                {
                    var Storagepath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/FOTOS1";
                    if (!Directory.Exists(Path.Combine(Storagepath, "ACH")))
                    {
                        Directory.CreateDirectory(Path.Combine(Storagepath, "ACH"));
                    }
                    string path = System.IO.Path.Combine(Storagepath.ToString(), selected.nombre.Trim()+".png");
                    System.IO.File.WriteAllBytes(path, selected.img2);
                    await DisplayAlert("INFO", "IMAGEN GUARDADA en !\n"+ Storagepath, "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERROR", "IMAGEN NO GUARDADA!", "OK");
                }
            }
        }
    }
}