using SQLite;

namespace VendasEstoque.Produtos

{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int ProdId { get; set; }
        public string ProdNome { get; set; }
        public int ProdEstoque { get; set; }
        public float ProdRSCompra { get; set; }
        public float ProdRSVenda { get; set; }
        public string ProdStatus { get; set; }
    }
}
