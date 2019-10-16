using System;
using System.IO;
using System.Linq;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VendasEstoque.Banco;


namespace VendasEstoque
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraCliente : ContentPage
    {
        Clientes clientes = new Clientes();
        public CadastraCliente()
        {
            InitializeComponent();
        }

        public void BtnSalvar_Clicked(object sender, EventArgs args)
        {
            Clientes clientes = new Clientes();/////////////////

             //TODO - Validar Dados do Cadastro
             if(entNomeCliente.Text == null || entCelCliente.Text == null || entTelCliente.Text == null || entEndCliente == null || entRSCliente.Text == null || entCidadeCliente.Text == null)
              //  || entNumCasa.Text == null || entEstadoCliente.Text == null || entCidadeCliente.Text == null)
             {
                DisplayAlert("Campos não preenchidos", "Preencha todos os campos obrigatórios!", "OK");
             }
            else
            {
                Clientes cliente = new Clientes();
                cliente.Cli_Nome = entNomeCliente.Text;
                cliente.Cli_RzSocial = entRSCliente.Text;
                cliente.Cli_Telefone = entTelCliente.Text;
                cliente.Cli_Celular = entCelCliente.Text;
                cliente.Cli_Endereco = entEndCliente.Text;
               // cliente.Cli_NumCasa = int.Parse(entNumCasa.Text);
                cliente.Cli_Cidade = entCidadeCliente.Text;
               // cliente.Cli_Estado = entEstadoCliente.Text;

                AcessoBanco acessobanco = new AcessoBanco();
                acessobanco.Cadastro_Cliente(cliente);

                DisplayAlert("Cadastro", "Cliente cadastrado!", "OK");

                //Checar aula 164 em caso de erros
                //Navigation.PopAsync();
                Navigation.PushAsync(new ConsultaClientes()); ;

            }

        }
    }
}