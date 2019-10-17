using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VendasEstoque.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Restaurar : ContentPage
    {
        public Restaurar()
        {
            InitializeComponent();
        }

        /*private void BtnBackup_Clicked(object sender, EventArgs e)
        {
            var dep = DependencyService.Get<ICaminho>();
            string db_path = dep.ObterCaminho("database.sqlite");
            //string backup_path = Path.Combine(Environment.GetFolderPath(), "database.txt");
            //string backup_path = Path.Combine(dep.GetPath(), "database.sqlite");

            var origin = File.ReadAllBytes(db_path);
            File.WriteAllBytes(backup_path, origin);

            DisplayAlert("BACKUP", "Backup criado!", "OK");
        }

        private async void BtnRestaurar_Clicked(object sender, EventArgs e)
        {

            var dep = DependencyService.Get<ICaminho>();
            string db_path = dep.ObterCaminho("database.sqlite");
            string backup_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "database.sqlite");

            if (File.Exists(db_path))
            {
                var resultado = DisplayAlert("Confirmação", "Deseja mesmo substituir o arquivo?", "SUBSTITUIR", "CANCELAR");
                lblConfirma.Text = await resultado ? "." : "";
                await Task.Delay(500);
                if (lblConfirma.Text == ".")
                {

                    var origin = File.ReadAllBytes(backup_path);
                    File.WriteAllBytes(db_path, origin);

                    DisplayAlert("RESTAURAÇÃO", "Backup restaurado!", "OK");
                    await Navigation.PopAsync();
                }

            }
            else
            {
                var origin = File.ReadAllBytes(backup_path);
                File.WriteAllBytes(db_path, origin);

                DisplayAlert("RESTAURAÇÃO", "Backup restaurado!", "OK");
                await Navigation.PopAsync();
            }
        }*/
    }
}