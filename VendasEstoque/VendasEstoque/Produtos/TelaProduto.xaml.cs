using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VendasEstoque.Produtos
{
    //CONSULTAVAGAS
    public partial class TelaProduto : ContentPage
    {
        List<Produto> ProdLista { get; set; }
        public TelaProduto()
        {
            InitializeComponent();

            AcessoBanco acessoBanco = new AcessoBanco();
            ProdLista = acessoBanco.ConsultarProd();
            ListaProdutos.ItemsSource = ProdLista;

            lblProdCount.Text = ProdLista.Count.ToString();
        }

        private void ToolbarCadastra_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IncluirProduto());

        }


        //Chama a página de detalhe pro produto selecionado pelo usuário
        public void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            Label lblDetalheProd = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblDetalheProd.GestureRecognizers[0];
            Produto produto = tapGest.CommandParameter as Produto;
            Navigation.PushAsync(new DetalharProduto(produto));
        }

        private void PesquisarAction(object sender, TextChangedEventArgs e)
        {
            ListaProdutos.ItemsSource = ProdLista.Where(a => a.ProdNome.Contains(e.NewTextValue)).ToList();

        }

        /*  private void Button_Clicked(object sender, EventArgs e)
          {
              Button button = (Button)sender;
              Produto produto = new Produto();
              Navigation.PushAsync(new DetalheProduto(produto));

          }*/

        public async void BtnApagarTudo_Clicked(object sender, EventArgs e)
        {
            var resultado = DisplayAlert("Confirmação", "Deseja mesmo excluir TODOS os produtos?", "OK", "CANCELAR");
            lblConfirma.Text = await resultado ? "." : "";
            await Task.Delay(500);
            if (lblConfirma.Text == ".")
            {
                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.DeleteAllProduto();
                await Navigation.PushAsync(new TelaProduto());
            }
        }
    }
}
