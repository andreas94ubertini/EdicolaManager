using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdicolaManager.Classes
{
    internal class Edicola
    {
        public string? Indirizzo { get; set; }
        public string? Nome { get; set; }
        public static List<Pubblicazione> Magazzino { get; set; } = new List<Pubblicazione>();
        public static List<Vendita>? Vendite { get; set; }
        public static List<Abbonamento>? Abbonamenti { get; set; }

        public Edicola() { }
        public void addToMagazzino(Pubblicazione p)
        {
            Magazzino.Add(p);
        }
        public void deleteFromMagazzino(Pubblicazione p)
        {
            Magazzino.Remove(p);
        }
        public void changeQuantity(int index, int newQt)
        {
            Magazzino[index].StockQt = newQt;
        } 
        public int findIndex(Pubblicazione p)
        {
            int index = Magazzino.IndexOf(p);
            return index;
        }
        public Rivista? findRivista(string titoloR)
        {
            foreach (Pubblicazione p in Magazzino) {
                if(p.GetType() == typeof(Rivista))
                {
                    Rivista temp = (Rivista)p;
                    if(temp.Titolo==titoloR) 
                        return temp;
                }
            }
            Console.WriteLine("Nessuna rivista trovata");
            return null;
        }
        public void addVendita(Vendita v)
        {
            if (v.Qt <= v.Rivista.StockQt)
            {
                if (Vendite == null)
                {
                    Vendite = new List<Vendita>();
                    Vendite.Add(v);
                    scalaVendita(v.Rivista, v.Qt);
                }
                else
                {
                    Vendite.Add(v);
                    scalaVendita(v.Rivista, v.Qt);
                }
                Console.WriteLine("Vendita registrata con successo");
            }
            else
            {
                Console.WriteLine("Quantità non presente");
            }

        }
        public void scalaVendita(Rivista r, int daScalare)
        {
            Pubblicazione? toFind = findRivista(r.Titolo);
            int index = findIndex(toFind);
            Magazzino[index].StockQt -= daScalare;
            Console.WriteLine($"Nuova quantità di {r.Titolo} : {Magazzino[index].StockQt}");


        }
        public void mostraVendite()
        {
            Console.WriteLine("==================Vendite per data=====================");
            List<Vendita> orderedBydate = Vendite.OrderBy(x => x.DataVendita).ToList();
            foreach(Vendita v in orderedBydate)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine("==================Fine Vendite per data=====================");

        }
        public void findByCat(string categoria)
        {
            if (categoria.ToUpper().Equals("GIORNALE"))
            {
                foreach (Pubblicazione p in Magazzino)
                {
                    if (p.GetType() == typeof(Giornale))
                    {
                        Giornale temp = (Giornale)p;
                        temp.Deatils();
                    }
                }
            }
            else
            {
                foreach (Pubblicazione p in Magazzino)
                {
                    if (p.GetType() == typeof(Rivista))
                    {
                        
                        Rivista temp = (Rivista)p;
                        if (temp.Categoria.ToUpper().Equals(categoria.ToUpper())){
                            temp.Deatils();

                        }
                    }
                }
            }
        }
        public void exportVenditeGiornaliere()
        {
            string? path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            string pathDue = "C:\\Utenti\\ubert\\Desktop\\Vendite.txt>";
            string fileName = "scontrini_";
            string today = Convert.ToString(DateTime.Now.ToString("yyyy_MM_dd"));
            try
            {
                using (StreamWriter sw = new StreamWriter(path+"\\Vendite\\"+fileName+today+".txt"))
                {
                    foreach(Vendita vendita in Vendite)
                    {
                        sw.WriteLine(vendita.exportCsv());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void mostraAbbonamenti()
        {
            if(Abbonamenti != null)
                foreach(Abbonamento a in Abbonamenti)
                {
                    Console.WriteLine(a.ToString());
                }
        }
        public void addAbbonamento(Abbonamento a)
        {
            if (Abbonamenti != null)
            {
                Abbonamenti.Add(a);
            }
            else
            {
                Abbonamenti = new List<Abbonamento> { a };
            }
            Console.WriteLine("Abbonamento aggiunto");
        }
        public Abbonamento? findAbbonamento(string? nominativo)
        {
            if(Abbonamenti != null)
                foreach (Abbonamento a in Abbonamenti)
                {

                   
                        if (a.Persona.Nominativo == nominativo)
                            return a;
                
                }
            Console.WriteLine("Nessun abbonamento trovato");
            return null;
        }
        public int indexAbbonamento (Abbonamento a)
        {

                int index = Abbonamenti.IndexOf(a);
                return index;
            
            
            
        }
        public void cambiaData(int index, DateTime data)
        {
            if (Abbonamenti[index] != null)
            {
                Abbonamenti[index].Consegna = data;
                Console.WriteLine("Data di consegna aggiornata");
            }
            else
            {
                Console.WriteLine("Errore, riprova per favore");
            }
        }

    }
}
