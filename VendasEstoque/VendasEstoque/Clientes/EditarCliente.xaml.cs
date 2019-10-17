using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasEstoque.Banco;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace VendasEstoque.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarCliente : ContentPage
    {
        Cliente cliente = new Cliente();
        public EditarCliente(Cliente cliente)
        {
            InitializeComponent();

            BindingContext = cliente;

            this.cliente = cliente;

            entNomeCliente.Text = cliente.Cli_Nome;
            entRSCliente.Text = cliente.Cli_RzSocial;
            entEndCliente.Text = cliente.Cli_Endereco;
            entNumCasa.Text = cliente.Cli_NumCasa.ToString();
            entCidadeCliente.Text = cliente.Cli_Cidade;
            entEstadoCliente.Text = cliente.Cli_Estado;
        }

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            if (entNomeCliente.Text == null || entRSCliente.Text == null || entEndCliente.Text == null || entNumCasa.Text == null || entCidadeCliente.Text == null || entEstadoCliente.Text == null)
            {
                DisplayAlert("Campos obrigatórios", "Preencha todos os campos obrigatórios!", "OK");
            }
            else
            {
                cliente.Cli_Nome = entNomeCliente.Text;
                cliente.Cli_RzSocial = entRSCliente.Text;
                cliente.Cli_Endereco = entEndCliente.Text;
                cliente.Cli_NumCasa = int.Parse(entNumCasa.Text);
                cliente.Cli_Cidade = entCidadeCliente.Text;
                cliente.Cli_Estado = cliente.Cli_Estado;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Cliente(cliente);

                DisplayAlert("Editar produto", "As alterações no produto forams salvas!", "OK");
               
                Navigation.PushAsync(new ConsultaClientes());
            }
        }

        private void BtnExcluir_Clicked(object sender, EventArgs e)
        {
            AcessoBanco acessoBanco = new AcessoBanco();
            acessoBanco.Exclusao_Cliente(cliente);
            Navigation.PushAsync(new ConsultaClientes());

        }
    }
}