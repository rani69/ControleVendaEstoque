using SQLite;

namespace VendasEstoque
{
    [Table("Clientes")]
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Cli_Id { get; set; }
        public string Cli_Nome { get; set; }
        public string Cli_Endereco { get; set; }
        public int Cli_NumCasa { get; set; }
        public string Cli_Cidade { get; set; }
        public string Cli_Estado { get; set; }
        public int Cli_Cpfcnpj { get; set; }
        public string Cli_Telefone { get; set; }
        public string Cli_Celular { get; set; }
        public string Cli_Data { get; set; }
        public string Cli_RzSocial{ get; set; }

    }
}
