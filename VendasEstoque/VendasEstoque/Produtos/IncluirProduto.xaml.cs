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
    public partial class IncluirProduto : ContentPage
    {

        Produto produtos = new Produto();
        public IncluirProduto(Produto produtos = null)
        {

            InitializeComponent();

        }


        private void BtnSalvarProd_Clicked(object sender, EventArgs e)
        {
            Produto produtos = new Produto();

            if (produtos.ProdId == 0)
            {
                produtos.ProdId += 1;

            }

            // Validar Dados do Cadastro
            if(entProd.Text == null || entQtde.Text == null || entRSCompra.Text == null || entRSVenda.Text == null)
            {
                DisplayAlert("Campos não preenchidos", "Preencha todos os campos obrigatórios!", "OK");
            }
            else
            {
                produtos.ProdNome = entProd.Text.ToLower();
                produtos.ProdEstoque = int.Parse(entQtde.Text.ToLower());
                produtos.ProdRSCompra = float.Parse(entRSCompra.Text);
                produtos.ProdRSVenda = float.Parse(entRSVenda.Text);
                produtos.ProdStatus = entEspecifica.Text.ToLower();

                AcessoBanco acessobanco = new AcessoBanco();
                acessobanco.Cadastrar_Produto(produtos);

                DisplayAlert("Cadastro de produtos", "Produto cadastrado!", "Ok");
                Navigation.PushAsync(new TelaProduto());
            }


        }
        private void BtnEditarProd_Clicked(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            Navigation.PushModalAsync(new DetalharProduto(produto));
        }

        private void BtnVoltar_Clicked3(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }


    }
}