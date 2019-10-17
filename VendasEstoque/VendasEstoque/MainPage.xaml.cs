using System;
using System.ComponentModel;
using Xamarin.Forms;
namespace VendasEstoque
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
   // [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnClientes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Clientes.ConsultaClientes());
           /* Clientes clientes = new Clientes();
            Navigation.PushAsync(new DetalhaCliente(clientes));*/
        }

        private void BtnEstoque_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Produtos.TelaProduto());

        }

        private void BtnVendas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Vendas.HistoricoVendas()); ;

        }

        private void BtnSobre_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sobre());

        }

        /*private void BtnRestaurar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Restore());
        }*/
    }
}
