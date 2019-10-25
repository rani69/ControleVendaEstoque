using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEstoque.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendasEstoque.Produtos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarProduto : ContentPage
    {
        List<Produto> ListaProd { get; set; }
        public BuscarProduto()
        {
            InitializeComponent();

            AcessoBanco acessoBanco = new AcessoBanco();
            ListaProd = acessoBanco.ConsultarProd();
            ProdLista.ItemsSource = ListaProd;
        }

        private void SearchProd_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProdLista.ItemsSource = ListaProd.Where(a => a.ProdNome.Contains(e.NewTextValue)).ToList();


        }

        private void TapBuscaProd_Tapped(object sender, EventArgs e)
        {

        }
    }
}