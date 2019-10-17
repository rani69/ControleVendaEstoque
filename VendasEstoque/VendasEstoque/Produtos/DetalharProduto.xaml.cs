using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEstoque.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Vendas;


namespace VendasEstoque.Produtos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalharProduto : ContentPage
    {
        Produto produto = new Produto();
        public DetalharProduto(Produto produto)
        {
            InitializeComponent();
            BindingContext = produto;

            this.produto = produto;

            entProd.Text = produto.ProdNome;
            entQtde.Text = produto.ProdEstoque.ToString();
            entRSCompra.Text = produto.ProdRSCompra.ToString("F");
            entRSVenda.Text = produto.ProdRSVenda.ToString("F");
            entStatus.Text = produto.ProdStatus;

        }
        public void BtnSalvarProd_Clicked(object sender, EventArgs args)
        {
            if (entProd.Text == null || entQtde.Text == null || entRSCompra.Text == null || entRSVenda.Text == null)
            {
                DisplayAlert("Campos obrigatórios", "Preencha todos os campos obrigatórios!", "OK");
            }
            else
            {
                //  ATUALIZAR NO BD
                produto.ProdNome = entProd.Text;
                produto.ProdEstoque = int.Parse(entQtde.Text);
                produto.ProdRSCompra = float.Parse(entRSCompra.Text);
                produto.ProdRSVenda = float.Parse(entRSVenda.Text);
                produto.ProdStatus = entStatus.Text;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Produto(produto);

                DisplayAlert("Editar produto", "As alterações no produto forams salvas!", "OK");
                //  REDIRECIONAR PARA A TELA MEUSPRODUTOS
                Navigation.PushAsync(new TelaProduto());
            }
        }
        private async void BtnExcluirProd_Clicked(object sender, EventArgs e)
        {
            var resultado = DisplayAlert("Confirmação", "Deseja mesmo apagar este registro?", "OK", "CANCELAR");
            lblConfirma.Text = await resultado ? "." : "";
            await Task.Delay(500);
            if (lblConfirma.Text == ".")
            {
                Button btnExcluir = (Button)sender;
                //TapGestureRecognizer tapGest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
                Produto produto = btnExcluir.CommandParameter as Produto;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Exclusao_Produto(produto);

                await Navigation.PushAsync(new VendaProduto());
            }
        }
    }
}