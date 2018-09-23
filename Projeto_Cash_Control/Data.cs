using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_Cash_Control
{
    public class Data
    {
        public DateTime atual { get; set; }
        public string mes { get; set; }


        public string MesAtual(DateTime dataSelecionada)
        {
            string mes = "None";
            int n = dataSelecionada.Month;

            if (n == 1)
                mes = "Janeiro";
            if (n == 2)
                mes = "Fevereiro";
            if (n == 3)
                mes = "Março";
            if (n == 4)
                mes = "Abril";
            if (n == 5)
                mes = "Maio";
            if (n == 6)
                mes = "Junho";
            if (n == 7)
                mes = "Julho";
            if (n == 8)
                mes = "Agosto";
            if (n == 9)
                mes = "Setembro";
            if (n == 10)
                mes = "Outubro";
            if (n == 11)
                mes = "Novembro";
            if (n == 12)
                mes = "Dezembro";

            return mes;

        }


    }
}