using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VendasEstoque.Banco;
using Xamarin.Forms;
using System.IO;
using VendasEstoque.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace VendasEstoque.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBiblioteca = Path.Combine(caminhoDaPasta, "..", "Library");

            string caminhoBanco = Path.Combine(caminhoBiblioteca, NomeArquivoBanco);

            return caminhoBanco;



        }
    }
}