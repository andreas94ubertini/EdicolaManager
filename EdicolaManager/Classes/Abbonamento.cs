using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Abbonamento
    {
        public DateTime? Consegna { get; set; }
        public Cliente? Persona { get; set; }
        public Rivista? Rivista { get; set; }

        public Abbonamento() { }
        public Abbonamento(DateTime? consegna, Cliente? persona, Rivista? rivista)
        {
            Consegna = consegna;
            Persona = persona;
            Rivista = rivista;
        }
        public override string ToString()
        {
            return $"[ABBONAMENTO] {Rivista.Titolo}, {Persona.Nominativo}, prossima consegna il {Consegna}";
        }
    }
}
