using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendasEstoque.Relatorios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelatorioVenda : ContentPage
    {
        private Venda venda { get; set; }
        public RelatorioVenda(Venda venda)
        {
            InitializeComponent();
            this.venda = venda;

            lblDataVenda.Text = venda.VendaData;
            lblCliente.Text = venda.CliNome;
            lblDesc.Text = venda.ProdNome;
            lblQtde.Text = venda.ProdQtde.ToString();
            lblRSVenda.Text = venda.ProdRSVenda.ToString();
            lblForma.Text = venda.FormaPagmento;
            // editObs.Text = vendas.VendaObs;
            lblObs.Text = venda.VendaObs;
            lblValorTot.Text = venda.TotalVenda.ToString();
            if (venda.VendaPaga == true)
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

                txt.WriteLine(string.Format(venda.VendaData));
                txt.WriteLine(string.Format(venda.CliNome));
                txt.WriteLine(string.Format(venda.ProdQtde.ToString()));
                txt.WriteLine(string.Format(venda.ProdRSVenda.ToString()));
                txt.WriteLine(string.Format(venda.FormaPagmento));
                txt.WriteLine(string.Format(venda.VendaObs));
                txt.WriteLine(string.Format(venda.TotalVenda.ToString()));
                txt.WriteLine(string.Format(lblVendaPaga.Text));
            }
        }

        private void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}

