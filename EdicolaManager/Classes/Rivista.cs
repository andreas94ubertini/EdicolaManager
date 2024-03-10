using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Rivista : Pubblicazione
    {
        public string? Titolo { get; set; }
        public string? Categoria { get; set; }
        public Rivista() { }
        public Rivista(double prezzo, string? codice, int stockQt, string? titolo, string? categoria)
        {
            Prezzo = prezzo;
            Codice = codice;
            StockQt = stockQt;
            Titolo = titolo;
            Categoria = categoria;
        }
        public override void Deatils()
        {
            Console.WriteLine($"[RIVISTA] {Prezzo} {Codice} {Titolo} {Categoria} Quantità: {StockQt}");
        }
    }
}
