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

    public partial class EditarVenda : ContentPage
    {
        Vendas vendas = new Vendas();
        //public Produto produto { get; set; }
        public EditarVenda(Vendas vendas)
        {
            InitializeComponent();
            this.vendas = vendas;

            entCliente.Text = vendas.CliNome;
            entDesc.Text = vendas.ProdNome;
            entQtde.Text = vendas.ProdQtde.ToString();
            entRSVenda.Text = vendas.ProdRSVenda.ToString("F");
            entForma.Text = vendas.FormaPagmento;
            editObs.Text = vendas.VendaObs;
            lblValorTot.Text = vendas.TotalVenda.ToString("F");
            if (vendas.VendaPaga == true)
            {
                checkBoxPG.IsChecked = true;
            }
            else
            {
                checkBoxPG.IsChecked = false;
            }

            //TODO - Adicionar contatos cliente
        }
        public void BtnSalvar_Clicked(object sender, EventArgs args)
        {
            if (entCliente.Text == null || entDesc.Text == null || entQtde.Text == null || entRSVenda.Text == null || entForma.Text == null)
            {
                DisplayAlert("Campos não preenchidos", "Preencha todos os campos obrigatórios!", "OK");
            }
            else
            {
                vendas.CliNome = entCliente.Text;
                vendas.ProdNome = entDesc.Text;
                vendas.ProdQtde = int.Parse(entQtde.Text);
                vendas.ProdRSVenda = decimal.Parse(entRSVenda.Text);
                vendas.FormaPagmento = entForma.Text;
                vendas.VendaObs = editObs.Text;
                vendas.TotalVenda = float.Parse(lblValorTot.Text);
                if (checkBoxPG.IsChecked == true)
                {
                    vendas.VendaPaga = true;
                }
                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Vendas(vendas);

                Navigation.PushAsync(new HistoricoVendas());
            }

        }
    }
}