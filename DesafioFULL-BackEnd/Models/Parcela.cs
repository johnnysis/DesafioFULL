using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFULL.Models
{
    public class Parcela
    {
        public int NumeroDaParcela { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public decimal ValorDaParcela { get; set; }
        public int DiasEmAtraso { get
            {
                return (int)(DateTime.Now.Date - DataDeVencimento.Date).TotalDays;
            }
        }
        public decimal ValorJuros { get; set; }

        public void CalculaValorJuros(decimal percentualJuros)
        {
            ValorJuros = (percentualJuros / 100 / 30) * DiasEmAtraso * ValorDaParcela;
        }
    }
}
