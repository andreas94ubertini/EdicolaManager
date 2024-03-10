using EdicolaManager.Classes;

namespace EdicolaManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edi = new Edicola();
            bool inserimento = true;
            while (inserimento)
            {
                Console.WriteLine("============================Edicola===================================");
                Console.WriteLine("Premi 1 per gestire l'inventario, 2 per la gestione delle vendite, 3 per cercare tra le pubblicazioni, 4 per gestire gli abbonamenti, 5 per salvare le vendite giornaliere, 9 per uscire");
                string? choice = Console.ReadLine();
                try
                {
                    int convertedChoice = Convert.ToInt32(choice);
                    switch (convertedChoice)
                    {
                        //Gestione inventario
                        case 1:
                            {

                                Console.WriteLine("Premi 1 per inserire una pubblicazione, 2 per vedere la lista, 3 per modificare quantità o eliminare");
                                int menuChoice = Convert.ToInt32(Console.ReadLine());
                                if (menuChoice == 1)
                                {
                                    Console.WriteLine("Che tipo di pubblicazione vuoi inserire?");
                                    string? tipo = Console.ReadLine();
                                    if (tipo != null && tipo.ToUpper().Equals("GIORNALE"))
                                    {
                                        Console.WriteLine("Inserisci Prezzo giornale");
                                        double prezzo = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Inserisci Codice giornale");
                                        string? codice = Console.ReadLine();
                                        Console.WriteLine("Inserisci la quantità di stock del giornale");
                                        int stockQt = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Inserisci Redazione giornale");
                                        string? redazione = Console.ReadLine();
                                        Console.WriteLine("Ha un inserto?, -1-Si -2-No");
                                        int inputInserto = Convert.ToInt32(Console.ReadLine());
                                        bool? hasInserto;
                                        if (inputInserto == 1)
                                        {
                                            hasInserto = true;
                                        }
                                        else if (inputInserto == 2)
                                        {
                                            hasInserto = false;
                                        }
                                        else
                                        {
                                            hasInserto = null;
                                        }
                                        Pubblicazione g = new Giornale(prezzo, codice, stockQt, redazione, hasInserto);
                                        edi.addToMagazzino(g);

                                    }
                                    else if (tipo != null && tipo.ToUpper().Equals("RIVISTA"))
                                    {
                                        Console.WriteLine("Inserisci Prezzo rivista");
                                        double prezzo = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine("Inserisci Codice rivista");
                                        string? codice = Console.ReadLine();
                                        Console.WriteLine("Inserisci la quantità di stock della rivista");
                                        int stockQt = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Inserisci Titolo rivista");
                                        string? titolo = Console.ReadLine();
                                        Console.WriteLine("Inserisci Categoria rivista");
                                        string? categoria = Console.ReadLine();
                                        Pubblicazione p = new Rivista(prezzo, codice, stockQt, titolo, categoria);
                                        edi.addToMagazzino(p);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nessuna opzione disponibile! Inserisci giornale o rivista");
                                    }

                                }
                                else if (menuChoice == 2)
                                {
                                    int count = 0;
                                    foreach (Pubblicazione p in Edicola.Magazzino)
                                    {
                                        if (p.GetType() == typeof(Giornale))
                                        {
                                            Giornale temp = (Giornale)p;
                                            temp.Deatils();
                                        }
                                        else if (p.GetType() == typeof(Rivista))
                                        {
                                            Rivista temp = (Rivista)p;
                                            temp.Deatils();

                                        }
                                        count++;
                                    }
                                }
                                else if (menuChoice == 3)
                                {
                                    Console.WriteLine("Inserisci il codice della pubblicazione");
                                    string? cod = Console.ReadLine();
                                    Pubblicazione? selected = Edicola.Magazzino.Find(p => p.Codice == cod);
                                    if (selected != null)
                                    {
                                        if (selected.GetType() == typeof(Giornale))
                                        {
                                            Giornale temp = (Giornale)selected;
                                            temp.Deatils();

                                        }
                                        else if (selected.GetType() == typeof(Rivista))
                                        {
                                            Rivista temp = (Rivista)selected;
                                            temp.Deatils();

                                        }
                                        Console.WriteLine("Premi 1 per aggiornare lo stock, 2 per eliminare");
                                        int userChoice = Convert.ToInt32(Console.ReadLine());
                                        if (userChoice == 1)
                                        {
                                            Console.WriteLine("Inserisci la nuova quantità");
                                            int newQt = Convert.ToInt32(Console.ReadLine());
                                            if (newQt >= 0)
                                            {
                                                int index = edi.findIndex(selected);
                                                edi.changeQuantity(index, newQt);
                                                Console.WriteLine("Quantità aggiornata con successo");
                                            }
                                        }
                                        else if (userChoice == 2)
                                        {
                                            edi.deleteFromMagazzino(selected);

                                        }

                                    }
                                }
                                break;
                            }
                        //Gestione delle vendite
                        case 2:
                            {
                                Console.WriteLine("Premi 1 per registrare una nuova vendita, 2 per vedere lo storico delle vendite ");
                                int venditaChoice = Convert.ToInt32(Console.ReadLine());
                                if (venditaChoice == 1)
                                {
                                    Console.WriteLine("Registra una nuova vendita");
                                    Console.WriteLine("Inserisci il titolo della rivista");
                                    string? rivistaToFind = Console.ReadLine();
                                    if (rivistaToFind != null)
                                    {
                                        Rivista? r = edi.findRivista(rivistaToFind);
                                        Console.WriteLine("Inserisci quantità da vendere");
                                        int qtToSell = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Premi 1 pagamento Carta, 2 pagamento in contanti");
                                        int pagamentoChoice = Convert.ToInt32(Console.ReadLine());
                                        string? pagamento;
                                        if (pagamentoChoice == 1)
                                        {
                                            pagamento = "Carta";
                                        }
                                        else if (pagamentoChoice == 2)
                                        {
                                            pagamento = "Cash";
                                        }
                                        else
                                        {
                                            pagamento = null;
                                        }
                                        if (qtToSell >= 1)
                                        {
                                            Vendita v = new Vendita(r, qtToSell, pagamento);
                                            edi.addVendita(v);

                                        }
                                        if (Edicola.Vendite != null)
                                        {
                                            foreach (Vendita v in Edicola.Vendite)
                                            {
                                                Console.WriteLine($"Vendita- {v.Rivista?.Titolo}, vendute {v.Qt}, il {v.DataVendita.ToString()}, pagamento {v.TipoPagamento}");
                                            }
                                        }

                                    }
                                }else if(venditaChoice == 2)
                                {
                                    edi.mostraVendite();
                                }
                                else
                                {
                                    Console.WriteLine("Scelta non valida");
                                }
                                break;
                            }
                        //Ricerca e filtra
                        case 3:
                            {
                                Console.WriteLine("Premi 1 per cercare per Titolo, 2 per cercare per categoria");
                                int cercaChoice = Convert.ToInt32(Console.ReadLine());
                                if(cercaChoice == 1)
                                {
                                    Console.WriteLine("Inserisci il titolo da ricercare");
                                    string? toSearch = Console.ReadLine();
                                    Rivista? r = edi.findRivista(toSearch);
                                    r.Deatils();
                                }else if (cercaChoice == 2)
                                {
                                    Console.WriteLine("Inserisci la categoria da ricercare");
                                    string? toSearch = Console.ReadLine();
                                    edi.findByCat(toSearch);

                                }
                                else
                                {
                                    Console.WriteLine("Errore, scelta non valida");
                                }
                                break;
                            }
                        //Gestione Abbonamenti
                        case 4:
                            {

                                Console.WriteLine("Premi 1 per aggiungere un nuovo abbonamento, 2 per programmare un abbonamento, 3 per vedere la lista ");
                                int abbonamentoChoice = Convert.ToInt32(Console.ReadLine());
                                if(abbonamentoChoice == 1)
                                {
                                    Console.WriteLine("Inserisci nominativo persona");
                                    string? nominativo = Console.ReadLine();
                                    Console.WriteLine("Inserisci indirizzo");
                                    string? indirizzo = Console.ReadLine();
                                    Console.WriteLine("Inserisci titolo rivista");
                                    string? toSearch = Console.ReadLine();
                                    Rivista? r = edi.findRivista(toSearch);
                                    if (r != null)
                                    {
                                        Console.WriteLine("Inserisci titolo data prossima consegna");
                                        string? dataConsegna = Console.ReadLine();
                                        DateTime convertedData = Convert.ToDateTime(dataConsegna);
                                        Cliente c = new Cliente(nominativo, indirizzo);
                                        Abbonamento a = new Abbonamento(convertedData, c, r);
                                        edi.addAbbonamento(a);
                                    }
                                    else
                                    {
                                        Console.WriteLine("==========================================");
                                    }

                                }
                                else if (abbonamentoChoice == 2)
                                {
                                    Console.WriteLine("Inserisci nominativo per cercare l'abbonamento");
                                    string? nominativo = Console.ReadLine();
                                    Abbonamento a = edi.findAbbonamento(nominativo);
                                    int indexAbbonamento = edi.indexAbbonamento(a);
                                    if(indexAbbonamento!= null)
                                    {
                                        Console.WriteLine("Inserisci una nuova data di consegna");
                                        string? nuovaData = Console.ReadLine();
                                        DateTime convertedDate = Convert.ToDateTime(nuovaData);
                                        edi.cambiaData(indexAbbonamento, convertedDate);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nessun abbonamento trovato");
                                    }
                                }
                                else if(abbonamentoChoice == 3)
                                {
                                    edi.mostraAbbonamenti();
                                }
                                break;
                            }
                        case 5:
                            {
                                edi.exportVenditeGiornaliere();
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("Chiusura programma....");

                                inserimento = false;
                                break;
                            }


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}