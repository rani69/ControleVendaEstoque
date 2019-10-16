using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEstoque.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalharProduto : ContentPage
    {
        Produtos produtos = new Produtos();
        public DetalharProduto(Produtos produtos)
        {
            InitializeComponent();
            BindingContext = produtos;

            this.produtos = produtos;

            entProd.Text = produtos.ProdNome;
            entQtde.Text = produtos.ProdEstoque.ToString();
            entRSCompra.Text = produtos.ProdRSCompra.ToString("F");
            entRSVenda.Text = produtos.ProdRSVenda.ToString("F");
            entStatus.Text = produtos.ProdStatus;

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
                produtos.ProdNome = entProd.Text;
                produtos.ProdEstoque = int.Parse(entQtde.Text);
                produtos.ProdRSCompra = float.Parse(entRSCompra.Text);
                produtos.ProdRSVenda = float.Parse(entRSVenda.Text);
                produtos.ProdStatus = entStatus.Text;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Produto(produtos);

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
                Produtos produtos = btnExcluir.CommandParameter as Produtos;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Exclusao_Produto(produtos);

                await Navigation.PushAsync(new VendaProduto());
            }
        }
    }
}