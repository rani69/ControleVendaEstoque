using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using VendasEstoque.Banco;

namespace VendasEstoque

{
    [Table("Produtos")]
    public class Produtos
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
