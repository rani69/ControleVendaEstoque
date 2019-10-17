using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;
using VendasEstoque;

namespace VendasEstoque.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaClientes : ContentPage
    {
        List<Cliente> Lista { get; set; }
        public ConsultaClientes()
        {
            InitializeComponent();

            AcessoBanco acessobanco = new AcessoBanco();
            Lista = acessobanco.Consultar();
            ListaClientes.ItemsSource = Lista;

            lblCount.Text = Lista.Count.ToString(); 
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapGest = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]);
            Cliente cliente = tapGest.CommandParameter as Cliente;

            Navigation.PushAsync(new Clientes.DetalhaCliente(cliente));

        }

        private void BtnCadastro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastraCliente());

        }

        private void EntPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaClientes.ItemsSource = Lista.Where(a => a.Cli_Nome.Contains(e.NewTextValue)).ToList();
        }
    }
}