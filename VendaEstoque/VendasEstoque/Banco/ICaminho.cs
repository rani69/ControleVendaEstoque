using System;
using System.Collections.Generic;
using System.Text;

namespace VendasEstoque.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string NomeArquivoBanco);

    }
}
