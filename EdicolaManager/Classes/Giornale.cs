using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Giornale : Pubblicazione
    {
        public string? Redazione { get; set; }
        public bool? HasInserto { get; set; }
        public Giornale() { }
        public Giornale(double prezzo, string? codice, int stockQt, string? redazione, bool? hasInserto)
        {
            Prezzo = prezzo;
            Codice = codice;
            StockQt = stockQt;
            Redazione = redazione;
            HasInserto = hasInserto;
        }
        public override void Deatils()
        {
            Console.WriteLine($"[GIORNALE] {Prezzo} {Codice} {Redazione} Quantità: {StockQt}");
        }
    }
}
