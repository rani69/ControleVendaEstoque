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
    public partial class DetalheRelatorio : ContentPage
    {
        private Vendas vendas { get; set; }
        public DetalheRelatorio()
        {
            InitializeComponent();
        }
        public DetalheRelatorio(int Id)
        {
            InitializeComponent();
            vendas.VendaId = Id;

            this.vendas = vendas;
            lblData.Text += vendas.VendaData;

            lblProdNome.Text = vendas.ProdNome;
            lblCliNome.Text = vendas.CliNome;
            lblQtde.Text = vendas.ProdQtde.ToString();
            lblRSUnita.Text = vendas.ProdRSVenda.ToString();
            lblFormaPgto.Text = vendas.FormaPagmento;
            lblRSTot.Text = vendas.TotalVenda.ToString();
            lblObs.Text = vendas.VendaObs;

        }
    }
}