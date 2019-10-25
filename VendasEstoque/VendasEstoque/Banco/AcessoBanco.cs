using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using VendasEstoque.Produtos;


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
            _conexao.CreateTables<Cliente, Venda, Produto>();
            
        }

        //---------------------------------- Cliente --------------------------------------------------

        public List<Cliente>Consultar()
        {
            
            return _conexao.Table<Cliente>().ToList();
        }
        public List<Cliente> PesquisarNome(string nome)
        {

            return _conexao.Table<Cliente>().Where(a=>a.Cli_Nome.Contains(nome)).ToList();
        }

        public Cliente ObterClientePorId(int id)
        {
            return _conexao.Table<Cliente>().Where(a=>a.Cli_Id==id).FirstOrDefault();
        }

        public void Cadastro_Cliente(Cliente cliente)
        {
            _conexao.Insert(cliente);
        }
        public void Exclusao_Cliente(Cliente cliente)
        {
            _conexao.Delete(cliente);
        }
        public void Atualizar_Cliente(Cliente cliente)
        {
            _conexao.Update(cliente);
        }

        //---------------------------------- Produto --------------------------------------------------

        public List<Produtos.Produto> ConsultarProd()
        {
            return _conexao.Table<Produto>().ToList();
        }
        public List<Produtos.Produto> PesquisarProdNome(string ProdNome)
        {

            return _conexao.Table<Produto>().Where(a => a.ProdNome.Contains(ProdNome)).ToList();
        }

               /* public <Produto>GetProdutoAsync(int id)
                {
                    return _conexao.Table<Produto>()
                                    .Where(i => i.ProdId == id)
                                    .FirstOrDefaultAsync();
                }*/

            /*    public decimal GetProdutoRS()
                {
                    return _conexao.Table<Produto>()
                                    .Where(i => i.ProdRSVenda);
                }*/


       public Produto ObterProdutoPorId(int ProdId)
       {
            return _conexao.Table<Produto>().Where(a => a.ProdId == ProdId).FirstOrDefault();
       }
   
       public void Cadastrar_Produto(Produto Produto)
       {
           _conexao.Insert(Produto);
       }
       public void Exclusao_Produto(Produto Produto)
       {
           _conexao.Delete(Produto);
                    //_conexao.Delete<Produto>(Produto.ProdId);
       }
       public void Atualizar_Produto(Produtos.Produto Produto)
       {
            _conexao.Update(Produto);
       }
        // Deletar todos os dados
       public void DeleteAllProduto()
       {
            _conexao.DeleteAll<Produto>();
       }
    /*  public bool Produto ChecarEstoqueProduto(string ProdNome)
      {
          if(_conexao.Table<Produto>().Where(a => a.ProdNome.Contains(ProdNome)))
          {

          }*/

    //---------------------------------- Vendas --------------------------------------------------

    public List<Venda> ConsultarVenda()
        {

            return _conexao.Table<Venda>().ToList();
        }


        public void Cadastrar_Vendas(Venda venda)
        {
            _conexao.Insert(venda);
        }
        public void Exclusao_Vendas(Venda venda)
        {
            _conexao.Delete(venda);
        }
        public void Atualizar_Vendas(Venda venda)
        {
            _conexao.Update(venda);
        }
    }
}
