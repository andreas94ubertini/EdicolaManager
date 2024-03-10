using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Cliente
    {
        public string? Nominativo { get; set; }
        public string? Indirizzo { get; set; }

        public Cliente() { }
        public Cliente(string? nominativo, string? indirizzo)
        {
            Nominativo = nominativo;
            Indirizzo = indirizzo;
        }
    }
}
