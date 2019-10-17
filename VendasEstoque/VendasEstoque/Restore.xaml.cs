using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;

namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Restore : ContentPage
    {
        public Restore()
        {
            InitializeComponent();
        }

        /*const string FileName = "database.sqlite";

        private void BtnBackup_Clicked(object sender, EventArgs e)
        {
            var dep = DependencyService.Get<ICaminho>();
            string db_path = dep.ObterCaminho("database.sqlite");
            string backup_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");

            var origin = File.ReadAllBytes(db_path);
            File.WriteAllBytes(backup_path, origin);

            DisplayAlert("BACKUP", "Backup criado!", "OK");
        }

        private async void BtnRestaurar_Clicked(object sender, EventArgs e)
        {

            var dep = DependencyService.Get<ICaminho>();
            string db_path = dep.ObterCaminho("database.sqlite");
            string backup_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");

            if (File.Exists(db_path))
            {
                var resultado = DisplayAlert("Confirmação", "Deseja mesmo substituir o arquivo?", "SUBSTITUIR", "CANCELAR");
                lblConfirma.Text = await resultado ? "." : "";
                await Task.Delay(500);
                if (lblConfirma.Text == ".")
                {

                    var origin = File.ReadAllBytes(backup_path);
                    File.WriteAllBytes(db_path, origin);

                   var dsp = DisplayAlert("RESTAURAÇÃO", "Backup restaurado!", "OK");
                   await Task.Delay(300);
                   await Navigation.PopAsync();
                }

            }
            

        }*/
    }
}