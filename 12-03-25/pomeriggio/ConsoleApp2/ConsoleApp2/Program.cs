using System;
using ConsoleApp2;
using Microsoft.Data.SqlClient;

namespace MyApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=NEGOZIODB;Trusted_Connection=True;TrustServerCertificate=True;";

            string strquery = "SELECT * FROM Prodotti";
            try
            {
                //creare connessione a db
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione aperta con successo");
                    using (SqlCommand cmd = new SqlCommand(strquery, connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //finchè legge
                            while (reader.Read())
                            {
                                //reader legge esattamente il nome della colonna
                                Console.WriteLine($"ID:  {reader["ID"]}, NOME: {reader["NOME_PRODOTTO"]} PREZZO: {reader["PREZZO"]} ");
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                //esegue se non riesce ad eseguire try
                Console.WriteLine("Catch se non eseguo try ");
                Console.WriteLine("Errore generico : " + e.Message);
            }
            finally
            {
                //viene sempre eseguito dopo il blocco try o catch
                Console.WriteLine("Eseguo sempre");
                Pcrud x = new Pcrud();
                mw.CreateProdotto();
            }

            to do:
            1 implementare connessione singleton -ok
            2 mvc pattern corretto -ok

            3 implementare crud totale di prodotti
            4 implementare entità categorieProdotti + crud totale + vincoli db
            5 -opt stringa di connessione fuori da progetto o fuori da classe(?)


            */
            bool running = true;
            MainView mw = new MainView();
            Pcrud pcrud = new Pcrud();
            CCrud cCrud = new CCrud();
            while (running)
            {
                mw.visualizzaMenù();
                int scelta = mw.LeggiIntero("inserisci la scelta:");
                string msg;

                switch (scelta)
                {
                    case 1:
                        //create prodotto
                        Prodotto newp = new Prodotto(); //passo prodotto vuoto a vista
                        newp = mw.CreateProdotto(newp); //vista accetta prodotto e lo restituisce valorizzato
                         msg = pcrud.createProdotto(newp); //createProdotto restituisce il messaggio di avvenuta creazione o meno
                        mw.LeggiStringa(msg); //leggo messaggio
                        break;
                    case 2:
                        //read prodotti
                        List<Prodotto> list = pcrud.viewAll();
                        mw.ViewAll(list);
                        break;
                    case 3:
                        //ricerca per Id prodotto
                        List<Prodotto> list1 = pcrud.viewAll();
                        mw.ViewAll(list1);
                        mw.selezionaId(pcrud);
                        break;
                    case 4:
                        //update prodotto
                        List<Prodotto> list2 = pcrud.viewAll();
                        mw.ViewAll(list2);
                        Prodotto pr = mw.selezionaId(pcrud);
                        Prodotto prm = mw.modificaProdotto(pr);
                        msg = pcrud.updateProdotto(prm);
                        mw.LeggiStringa(msg);
                        break;
                    case 5:
                        //delete prodotto
                        List<Prodotto> list3 = pcrud.viewAll();
                        mw.ViewAll(list3);
                        Prodotto p = mw.selezionaId(pcrud);
                        msg = pcrud.deleteProdotto(p);
                        mw.LeggiStringa(msg);
                        break;
                    case 6:
                        //create categoria
                        Categoria categoria = new Categoria();
                        categoria = mw.CreateCategoria(categoria);
                        msg = cCrud.createCategoria(categoria);
                        mw.LeggiStringa(msg);
                        break;
                    case 7:
                        //mostra tutte le categorie

                        break;
                    case 8:
                        //ricerca una categoria per Id
                        break;
                    case 9:
                        //modifica una categoria
                        break;
                    case 10:
                        //elimina una categoria
                        break;


                    default:
                        mw.LeggiStringa("Scelta non valida..");
                        break;
                }
            }
        }
    }
}