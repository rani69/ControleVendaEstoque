using System;
using System.IO;
using Android.App;
using Java.Security.Cert;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

//using Xamarin.Forms;

namespace VendasEstoque.Droid
{
    public class FileAccessHelper
    {
        public string ObterPath(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBanco);

            return caminhoBanco;
        }

        public void CopyDatabaseIfNotExists(string NomeArquivoBanco)
        {
            

            string novoCaminhoBanco = ObterPath(NomeArquivoBanco);
            if(File.Exists(novoCaminhoBanco) == false)
            {                    using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(NomeArquivoBanco)))
                    {
                        using (var bw = new BinaryWriter(new FileStream(novoCaminhoBanco, FileMode.Create)))
                        {
  
                            byte[] buffer = new byte[2048];
                            int len = 0;

                            while((len = br.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                bw.Write(buffer, 0, len);
                            }
                        }
                    }
            }
            else
            {
                Debug.Write("Erro");

            }
                
        }

    }
}