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
        private Venda venda { get; set; }
        public DetalheRelatorio()
        {
            InitializeComponent();
        }
        public DetalheRelatorio(int Id)
        {
            InitializeComponent();
            venda.VendaId = Id;

            this.venda = venda;
            lblData.Text += venda.VendaData;

            lblProdNome.Text = venda.ProdNome;
            lblCliNome.Text = venda.CliNome;
            lblQtde.Text = venda.ProdQtde.ToString();
            lblRSUnita.Text = venda.ProdRSVenda.ToString();
            lblFormaPgto.Text = venda.FormaPagmento;
            lblRSTot.Text = venda.TotalVenda.ToString();
            lblObs.Text = venda.VendaObs;

        }
    }
}