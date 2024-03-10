using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Vendita
    {
        public Rivista? Rivista { get; set; }
        public DateTime? DataVendita { get; set; }
        public int Qt { get; set; }
        public string? TipoPagamento { get; set; }
        public Vendita() { }
        public Vendita(Rivista? rivista, int qt, string? tipoPagamento)
        {
            Rivista = rivista;
            Qt = qt;
            DataVendita = DateTime.Now;
            TipoPagamento = tipoPagamento;
        }
        public override string ToString()
        {
            return $"[RIVISTA] Venduta il {DataVendita}, Qt {Qt}, Titolo {Rivista.Titolo}";
        }
        public string exportCsv()
        {
            return $"{Rivista.Titolo};{DataVendita.ToString()};{Qt};{TipoPagamento}";
        }
    }
}
