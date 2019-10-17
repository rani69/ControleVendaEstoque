using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;

namespace VendasEstoque.Vendas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class EditarVenda : ContentPage
    {
        Venda venda = new Venda();
        //public Produto produto { get; set; }
        public EditarVenda(Venda venda)
        {
            InitializeComponent();
            this.venda = venda;

            entCliente.Text = venda.CliNome;
            entDesc.Text = venda.ProdNome;
            entQtde.Text = venda.ProdQtde.ToString();
            entRSVenda.Text = venda.ProdRSVenda.ToString("F");
            entForma.Text = venda.FormaPagmento;
            editObs.Text = venda.VendaObs;
            lblValorTot.Text = venda.TotalVenda.ToString("F");
            if (venda.VendaPaga == true)
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
                venda.CliNome = entCliente.Text;
                venda.ProdNome = entDesc.Text;
                venda.ProdQtde = int.Parse(entQtde.Text);
                venda.ProdRSVenda = decimal.Parse(entRSVenda.Text);
                venda.FormaPagmento = entForma.Text;
                venda.VendaObs = editObs.Text;
                venda.TotalVenda = float.Parse(lblValorTot.Text);
                if (checkBoxPG.IsChecked == true)
                {
                    venda.VendaPaga = true;
                }
                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Vendas(venda);

                Navigation.PushAsync(new HistoricoVendas());
            }

        }
    }
}