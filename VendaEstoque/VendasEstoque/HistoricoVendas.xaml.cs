using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;

//TelaProdutos  
namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricoVendas : ContentPage
    {
        List<Vendas> VendaLista { get; set; }

        public HistoricoVendas()
        {
            InitializeComponent();

            AcessoBanco acessoBanco = new AcessoBanco();
            VendaLista = acessoBanco.ConsultarVenda();
            ListaVendas.ItemsSource = VendaLista;

            lblVendaCount.Text = VendaLista.Count.ToString();
        }
        private void BtnNvaVenda_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VendaProduto());
        }
        
        //Chama a página de detalhe pro produto selecionado pelo usuário
        public void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            Label lblGoRelatorio = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblGoRelatorio.GestureRecognizers[0];
            Vendas vendas = tapGest.CommandParameter as Vendas;
            Navigation.PushAsync(new RelatorioVenda(vendas));
        }

        private void TapEditarVenda_Tapped(object sender, EventArgs e)
        {
            Label lblGoRelatorio = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblGoRelatorio.GestureRecognizers[0];
            Vendas vendas = tapGest.CommandParameter as Vendas;
            Navigation.PushAsync(new EditarVenda(vendas));

        }
    }
}