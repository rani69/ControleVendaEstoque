using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;

namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VendaProduto : ContentPage
    {
        Vendas vendas = new Vendas();
        //Clientes clientes = new Clientes();
        public VendaProduto()
        {
            InitializeComponent();
            DateTime dateAndTime = DateTime.Now;
            lblData.Text += dateAndTime.ToString("dd/MM/yyyy");
            if(vendas.VendaId == 0)
            {
                vendas.VendaId = 1;
            }
            vendas.VendaId += 1;
        }

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
            Vendas vendas = new Vendas();
            AcessoBanco acessoBanco = new AcessoBanco();
            List<Produtos> produtos = acessoBanco.ConsultarProd();
            int HaveResult = produtos[0].ProdEstoque;
            var qtdeVenda = int.Parse(entQtde.Text);

            if (entCliente.Text == null || entDesc.Text == null || entQtde.Text == null || int.Parse(entQtde.Text) < 1 || entRSVenda.Text == null || entForma == null)
            {
                DisplayAlert("AVISO", "Preencha todos os campos obrigatórios.", "OK");
            }
            else
            {
                if (HaveResult >= qtdeVenda)
                {
                    produtos[0].ProdEstoque -= qtdeVenda;
                    AcessoBanco acessobanco = new AcessoBanco();
                    var listaProd = acessobanco.PesquisarProdNome(entDesc.Text);
                    if (listaProd.Count() <= 0)
                    {
                        DisplayAlert("Produto não cadastrado", "Favor checar o estoque", "OK");
                    }
                    else
                    {   //TODO - Checar se o cliente está cadastrado
                        //var listaCli = acessobanco.PesquisarNome(entCliente.Text.ToLower());
                        /*if(listaCli.Count() <= 0){
                        DisplayAlert("Cliente não Cadastrado", "Cheque os clientes cadastrados", "OK");*/

                        vendas.CliNome = entCliente.Text.ToLower();
                        vendas.ProdNome = entDesc.Text.ToLower();
                        vendas.ProdQtde = int.Parse(entQtde.Text.ToLower());
                        vendas.ProdRSVenda = decimal.Parse(entRSVenda.Text);
                        vendas.FormaPagmento = entForma.Text.ToLower();
                        float totVenda;
                        bool canParseTot = float.TryParse(entRSVenda.Text, out totVenda);

                        if (canParseTot)
                        {
                            vendas.TotalVenda = totVenda;
                        }
                        else
                        {
                            DisplayAlert("Erro", "Quantidade/Valor unitário inválido!", "OK");
                        }
                        if (editObs.Text != null)
                        {
                            vendas.VendaObs = editObs.Text.ToLower();
                        }
                        vendas.VendaData = lblData.Text;
                        //Checar se a venda já está paga
                        if (checkBoxPG.IsChecked)
                        {
                            vendas.VendaPaga = true;
                        }
                        else
                        {
                            vendas.VendaPaga = false;
                        }
                        //Salvar os dados no banco
                        AcessoBanco acesso_banco = new AcessoBanco();
                        acesso_banco.Cadastrar_Vendas(vendas);

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