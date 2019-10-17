using System;
using System.Collections.Generic;
using System.Text;
using VendasEstoque.Banco;
using SQLite;

namespace VendasEstoque
{
    [Table("Vendas")]
    public class Venda
    {
        [PrimaryKey, AutoIncrement]
        public int VendaId { get; set; }
        public int CliId { get; set; }
        public string CliNome { get; set; }
        public string ProdNome { get; set; }
        public int ProdQtde { get; set; }
        public decimal ProdRSVenda { get; set; }
        public string FormaPagmento { get; set; }
        public float TotalVenda { get; set; }
        public string VendaObs { get; set; }
        public string VendaData { get; set; }
        public bool VendaPaga { get; set; }
    }
}