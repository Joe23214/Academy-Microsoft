using System;
using System.Collections.Generic;
using ConsoleApp1;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connessione a db con stringa
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GUNIV;Trusted_Connection=True;TrustServerCertificate=True;";



            StRepository repo = new StRepository(connectionString);
            ContattiView view = new ContattiView();

            bool running = true;

            while (running)
            {
              
                view.DisplayMenu();
                int scelta = view.getChoice();

                switch (scelta)
                {
                    case 1:
                  
                        List<Contatto> contatti = repo.FindAll();
                        view.DisplayContatti(contatti);
                        break;

                    case 2:
            
                        Contatto nuovo = view.GetNewContattoData();
                        view.DisplaySuccess("Funzione inserimento non ancora implementata.");
                        break;

                    case 3:
                        view.DisplayError("Modifica contatto non implementata.");
                        break;

                    case 4:
                        view.DisplayError("Elimina contatto non implementata.");
                        break;

                    case 5:
                        view.DisplayError("Visualizza titoli di studio non implementata.");
                        break;

                    case 0:
                        running = false;
                        break;

                    default:
                        view.DisplayError("Scelta non valida.");
                        break;
                }

                Console.WriteLine("\nPremi un tasto per continuare...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
