using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;
using VendasEstoque.Produtos;
using SQLite;

namespace VendasEstoque.Vendas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VendaProduto : ContentPage
    {
        Venda vendas = new Venda();
        //Clientes clientes = new Clientes();
        public VendaProduto()
        {
            InitializeComponent();
            DateTime dateAndTime = DateTime.Now;
            lblData.Text += dateAndTime.ToString("dd/MM/yyyy");
            if (vendas.VendaId == 0)
            {
                vendas.VendaId = 1;
            }
            vendas.VendaId += 1;
            this.BindingContext = new ProdModel
            {
                ProdutoList = GetProdInfo()

            };

        }
        private SQLiteConnection _conexao;
        // Picker de Produtos
        private List<Produto> GetProdInfo()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);

            var db = _conexao.Table<Produto>();
            return db.ToList();

        }
        // Picker de Clientes

        private void EntQtde_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (entQtde.Text != null)
            {
                int Qtde;
                bool canParseI = int.TryParse(entQtde.Text, out Qtde);
                decimal RSVenda;
                bool canParseF = decimal.TryParse(entRSVenda.Text, out RSVenda);

                if (canParseF & canParseI)
                {
                    lblValorTot.Text = (Qtde * RSVenda).ToString();
                }
                else
                {
                    DisplayAlert("Erro", "Quantidade/Valor unitário inválido!", "OK");
                }
            }
        }

        private void EntRSVenda_TextChanged(object sender, TextChangedEventArgs e)
        { 

            if (entRSVenda.Text != null)
            {
                decimal RSVenda;
                bool canParseF = decimal.TryParse(entRSVenda.Text, out RSVenda);
                int Qtde;
                bool canParseI = int.TryParse(entQtde.Text, out Qtde);

                if (canParseF & canParseI)
                {
                    lblValorTot.Text = (Qtde * RSVenda).ToString();
                }
                else
                {
                    DisplayAlert("Erro", "Quantidade/Valor unitário inválido!", "OK");
                }
            }
        }
        public void BtnVenda_Clicked(object sender, EventArgs e)
        {
            //TODO -- Checar se tem produto no estoque
            Venda venda = new Venda();
            AcessoBanco acessoBanco = new AcessoBanco();
            List<Produto> produto = acessoBanco.ConsultarProd();
            int HaveResult = produto[0].ProdEstoque;
            var qtdeVenda = int.Parse(entQtde.Text);

            if (entCliente.Text == null ||  entQtde.Text == null || int.Parse(entQtde.Text) < 1 || entRSVenda.Text == null || entForma == null)
            {
                DisplayAlert("AVISO", "Preencha todos os campos obrigatórios.", "OK");
            }
            else
            {
                if (HaveResult >= qtdeVenda)
                {
                    produto[0].ProdEstoque -= qtdeVenda;
                    AcessoBanco acessobanco = new AcessoBanco();
                    var listaProd = acessobanco.PesquisarProdNome(lblProdNome.Text);
                    if (listaProd.Count() <= 0)
                    {
                        DisplayAlert("Produto não cadastrado", "Favor checar o estoque", "OK");
                    }
                    else
                    {   //TODO - Checar se o clIente está cadaStrAdo
                        //var lIstaCli = acessobanco.PesquisarNome(entCliente.Text.ToLower());
                        /*if(liStaCli.Count() <= 0){
                        DisplayAlert("Cliente não CAdastrado", "Cheque os clientes cadastrados", "OK");*/

                        venda.CliNome = entCliente.Text.ToLower();
                        venda.ProdNome = lblProdNome.Text.ToLower();
                        venda.ProdQtde = int.Parse(entQtde.Text.ToLower());
                        venda.ProdRSVenda = decimal.Parse(entRSVenda.Text);
                        venda.FormaPagmento = entForma.Text.ToLower();

                        float totVenda;
                        bool canParseTot = float.TryParse(entRSVenda.Text, out totVenda);

                        if (canParseTot)
                        {
                            venda.TotalVenda = totVenda;
                        }
                        else
                        {
                            DisplayAlert("Erro", "Quantidade/Valor unitário inválido!", "OK");
                        }
                        if (editObs.Text != null)
                        {
                            venda.VendaObs = editObs.Text.ToLower();
                        }
                        venda.VendaData = lblData.Text;
                        //Checar se a venda já está paga
                        if (checkBoxPG.IsChecked)
                        {
                            venda.VendaPaga = true;
                        }
                        else
                        {
                            venda.VendaPaga = false;
                        }
                        //Salvar os dados no banco
                        AcessoBanco acesso_banco = new AcessoBanco();
                        acesso_banco.Cadastrar_Vendas(venda);

                        DisplayAlert("Venda", "Venda Realizada!", "OK");

                        //Voltar para a página HistóricoVendas
                        Navigation.PushAsync(new HistoricoVendas());
                    }
                }

            }
        }

            //Editar VENDA
        private void BtnEditarVenda_Clicked(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new EditarVenda(vendas));
        }

        private void BtnBuscaProd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BuscarProduto());

        }
    }
    /* private Produto produto { get; set; }
    //Pegar o preço do produto e calcular o valor TOTAL
    private void btnPrecoClicked(object sender, EventArgs e)
 {
     AcessoBanco acessoBanco = new AcessoBanco();
     List<Produto> produtos = acessoBanco.ConsultarProd();
     float prc = produto.ProdRSVenda;
     entRSVenda.Text = prc.ToString();
     float Result = produtos[0].ProdRSVenda;
     if (Result > 0)
     {

         entRSVenda.Text = produto.ProdRSVenda.ToString();
         float tot = (float.Parse(entRSVenda.Text)) * int.Parse(entQtde.Text);
         lblValorTot.Text = tot.ToString();
     }
 }*/

}