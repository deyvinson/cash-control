using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Projeto_Cash_Control
{
    public class Log
    {
        public void UpdateLog(string mensagem)
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
            string dataHora = DateTime.Now.ToString();

            
            using (var arquivo = File.AppendText(caminho))
            {
                arquivo.WriteLine(dataHora + " : " + mensagem);
                arquivo.Close();
            }

        }
    }
}