using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VendasEstoque.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhaCliente : ContentPage
    {

        public DetalhaCliente(Cliente cliente)
        {
            InitializeComponent();
            BindingContext = cliente;
            //Navigation.PushAsync(new EditarCliente(cliente));   
        }

        private void BtnVoltar_Clicked2(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}