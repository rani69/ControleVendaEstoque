using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelatorioVenda : ContentPage
    {
        private Vendas vendas { get; set; }
        public RelatorioVenda(Vendas vendas)
        {
            InitializeComponent();
            this.vendas = vendas;

            lblDataVenda.Text = vendas.VendaData;
            lblCliente.Text = vendas.CliNome;
            lblDesc.Text = vendas.ProdNome;
            lblQtde.Text = vendas.ProdQtde.ToString();
            lblRSVenda.Text = vendas.ProdRSVenda.ToString();
            lblForma.Text = vendas.FormaPagmento;
            // editObs.Text = vendas.VendaObs;
            lblObs.Text = vendas.VendaObs;
            lblValorTot.Text = vendas.TotalVenda.ToString();
            if (vendas.VendaPaga == true)
            {
                lblVendaPaga.Text = "O pagamento para esta compra já foi realizado.";
            }
            else
            {
                lblVendaPaga.Text = "O pagamento para esta compra ainda não foi realizado.";
            }

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Relatorio.txt");
            using (StreamWriter txt = new StreamWriter(path))
            {

                txt.WriteLine(string.Format(vendas.VendaData));
                txt.WriteLine(string.Format(vendas.CliNome));
                txt.WriteLine(string.Format(vendas.ProdQtde.ToString()));
                txt.WriteLine(string.Format(vendas.ProdRSVenda.ToString()));
                txt.WriteLine(string.Format(vendas.FormaPagmento));
                txt.WriteLine(string.Format(vendas.VendaObs));
                txt.WriteLine(string.Format(vendas.TotalVenda.ToString()));
                txt.WriteLine(string.Format(lblVendaPaga.Text));
            }
        }

        private void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}

