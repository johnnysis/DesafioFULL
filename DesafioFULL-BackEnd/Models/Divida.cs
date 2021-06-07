using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFULL.Models
{
    public class Divida
    {
        public int NumeroDoTitulo { get; set; }
        public Devedor Devedor { get; set; }
        public decimal PercentualMulta { get; set; }
        public decimal PercentualJuros { get; set; }
        public List<Parcela> Parcelas { get; set; }
        
        public decimal ValorMulta { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorOriginal { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorAtualizado { get; set; }
        
        public void CalculaValorMulta()
        {
            ValorMulta = ValorOriginal * PercentualMulta / 100;
        }
        private void CalculaDiasEmAtraso()
        {
            if (Parcelas != null && Parcelas.Count > 0)
            {
                DateTime vencimentoPrimeiraParcela = Parcelas.Count > 0 ? Parcelas[0].DataDeVencimento : DateTime.Now;

                TimeSpan diferenca = DateTime.Now.Date - vencimentoPrimeiraParcela.Date;
                DiasEmAtraso = (int)diferenca.TotalDays;
            }
        }
        private void CalculaValorOriginal()
        {
            if (Parcelas != null && Parcelas.Count > 0)
                ValorOriginal = Parcelas.Sum(p => p.ValorDaParcela);
        }
        private void CalculaValorJuros()
        {
            if (Parcelas != null && Parcelas.Count > 0)
            {
                CalculaValorJurosParcelas();
                ValorJuros = Parcelas.Sum(p => p.ValorJuros);
            }
        }
        private void CalculaValorJurosParcelas()
        {
            if(Parcelas != null && Parcelas.Count > 0)
                Parcelas.ForEach(p => p.CalculaValorJuros(PercentualJuros));
        }
        private void CalculaValorAtualizado()
        {
            ValorAtualizado = ValorOriginal + ValorJuros + ValorMulta;
        }

        public void CalculaDivida()
        {
            CalculaValorOriginal();
            CalculaDiasEmAtraso();
            CalculaValorJuros();
            CalculaValorMulta();
            CalculaValorAtualizado();
        }
    }
}
