using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using System.Data.SqlTypes;
using System;
using System.Linq;

namespace VendasEstoque.Banco 
{
    class AcessoBanco
    {
        private SQLiteConnection _conexao;

        public AcessoBanco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");


            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTables<Clientes, Produtos, Vendas>();
            
        }

        //---------------------------------- Clientes --------------------------------------------------

        public List<Clientes>Consultar()
        {
            
            return _conexao.Table<Clientes>().ToList();
        }
        public List<Clientes> PesquisarNome(string nome)
        {

            return _conexao.Table<Clientes>().Where(a=>a.Cli_Nome.Contains(nome)).ToList();
        }

        public Clientes ObterClientePorId(int id)
        {
            return _conexao.Table<Clientes>().Where(a=>a.Cli_Id==id).FirstOrDefault();
        }

        public void Cadastro_Cliente(Clientes cliente)
        {
            _conexao.Insert(cliente);
        }
        public void Exclusao_Cliente(Clientes cliente)
        {
            _conexao.Delete(cliente);
        }
        public void Atualizar_Cliente(Clientes cliente)
        {
            _conexao.Update(cliente);
        }

             //---------------------------------- Produtos --------------------------------------------------

                public List<Produtos> ConsultarProd()
                {

                    return _conexao.Table<Produtos>().ToList();
                }
                public List<Produtos> PesquisarProdNome(string ProdNome)
                {

                    return _conexao.Table<Produtos>().Where(a => a.ProdNome.Contains(ProdNome)).ToList();
                }

               /* public <Produtos>GetProdutoAsync(int id)
                {
                    return _conexao.Table<Produtos>()
                                    .Where(i => i.ProdId == id)
                                    .FirstOrDefaultAsync();
                }*/

            /*    public decimal GetProdutoRS()
                {
                    return _conexao.Table<Produtos>()
                                    .Where(i => i.ProdRSVenda);
                }*/


                public Produtos ObterProdutoPorId(int ProdId)
                {
                    return _conexao.Table<Produtos>().Where(a => a.ProdId == ProdId).FirstOrDefault();
                }

                public void Cadastrar_Produto(Produtos produtos)
                {
                    _conexao.Insert(produtos);
                }
                public void Exclusao_Produto(Produtos produtos)
                {
                    _conexao.Delete(produtos);
                    //_conexao.Delete<Produto>(produtos.ProdId);
                }
                public void Atualizar_Produto(Produtos produtos)
                {
                    _conexao.Update(produtos);
                }

                // Deletar todos os dados
                public void DeleteAllProdutos()
                {
                    _conexao.DeleteAll<Produtos>();
                }
    /*  public bool Produto ChecarEstoqueProduto(string ProdNome)
      {
          if(_conexao.Table<Produto>().Where(a => a.ProdNome.Contains(ProdNome)))
          {

          }*/

    //---------------------------------- Vendas --------------------------------------------------

    public List<Vendas> ConsultarVenda()
        {

            return _conexao.Table<Vendas>().ToList();
        }

        /*public Vendas ObterVendaPorId(int VendaId)
        {
            return _conexao.Table<Vendas>().Where(a => a.VendaId == VendaId).FirstOrDefault();
        }

        public List<Vendas> PesquisarVendaProProd(string ProdNome)
        {

            return _conexao.Table<Vendas>().Where(a => a.ProdNome.Contains(ProdNome)).ToList();
        }*/


        public void Cadastrar_Vendas(Vendas vendas)
        {
            _conexao.Insert(vendas);
        }
        public void Exclusao_Vendas(Vendas vendas)
        {
            _conexao.Delete(vendas);
        }
        public void Atualizar_Vendas(Vendas vendas)
        {
            _conexao.Update(vendas);
        }
    }
}
