using System;
using System.IO;
using System.Linq;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;


namespace VendasEstoque.Clientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraCliente : ContentPage
    {
        Cliente cliente = new Cliente();
        public CadastraCliente()
        {
            InitializeComponent();
        }

        public void BtnSalvar_Clicked(object sender, EventArgs args)
        {
            Cliente cliente = new Cliente();

             //TODO - Validar Dados do Cadastro
             if(entNomeCliente.Text == null || entCelCliente.Text == null || entTelCliente.Text == null || entEndCliente == null || entRSCliente.Text == null || entCidadeCliente.Text == null)
              //  || entNumCasa.Text == null || entEstadoCliente.Text == null || entCidadeCliente.Text == null)
             {
                DisplayAlert("Campos não preenchidos", "Preencha todos os campos obrigatórios!", "OK");
             }
            else
            {
                Cliente clientes = new Cliente();
                clientes.Cli_Nome = entNomeCliente.Text;
                clientes.Cli_RzSocial = entRSCliente.Text;
                clientes.Cli_Telefone = entTelCliente.Text;
                clientes.Cli_Celular = entCelCliente.Text;
                clientes.Cli_Endereco = entEndCliente.Text;
               // cliente.Cli_NumCasa = int.Parse(entNumCasa.Text);
                clientes.Cli_Cidade = entCidadeCliente.Text;
               // cliente.Cli_Estado = entEstadoCliente.Text;

                AcessoBanco acessobanco = new AcessoBanco();
                acessobanco.Cadastro_Cliente(cliente);

                DisplayAlert("Cadastro", "Cliente cadastrado!", "OK");

                //Checar aula 164 em caso de erros
                //Navigation.PopAsync();
                Navigation.PushAsync(new ConsultaClientes());

            }

        }
    }
}