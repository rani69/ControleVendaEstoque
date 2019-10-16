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
    public partial class EditarCliente : ContentPage
    {
        Clientes clientes = new Clientes();
        public EditarCliente(Clientes clientes)
        {
            InitializeComponent();

            BindingContext = clientes;

            this.clientes = clientes;

            entNomeCliente.Text = clientes.Cli_Nome;
            entRSCliente.Text = clientes.Cli_RzSocial;
            entEndCliente.Text = clientes.Cli_Endereco;
            entNumCasa.Text = clientes.Cli_NumCasa.ToString();
            entCidadeCliente.Text = clientes.Cli_Cidade;
            entEstadoCliente.Text = clientes.Cli_Estado;
        }

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            if (entNomeCliente.Text == null || entRSCliente.Text == null || entEndCliente.Text == null || entNumCasa.Text == null || entCidadeCliente.Text == null || entEstadoCliente.Text == null)
            {
                DisplayAlert("Campos obrigatórios", "Preencha todos os campos obrigatórios!", "OK");
            }
            else
            {
                clientes.Cli_Nome = entNomeCliente.Text;
                clientes.Cli_RzSocial = entRSCliente.Text;
                clientes.Cli_Endereco = entEndCliente.Text;
                clientes.Cli_NumCasa = int.Parse(entNumCasa.Text);
                clientes.Cli_Cidade = entCidadeCliente.Text;
                clientes.Cli_Estado = clientes.Cli_Estado;

                AcessoBanco acessoBanco = new AcessoBanco();
                acessoBanco.Atualizar_Cliente(clientes);

                DisplayAlert("Editar produto", "As alterações no produto forams salvas!", "OK");
               
                Navigation.PushAsync(new ConsultaClientes());
            }
        }

        private void BtnExcluir_Clicked(object sender, EventArgs e)
        {
            AcessoBanco acessoBanco = new AcessoBanco();
            acessoBanco.Exclusao_Cliente(clientes);
            Navigation.PushAsync(new ConsultaClientes());

        }
    }
}