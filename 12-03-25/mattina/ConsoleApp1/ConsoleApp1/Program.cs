using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PROVA;Trusted_Connection=True;TrustServerCertificate=True;";

            Crud repoContatti = new Crud(connectionString);
            CrudTitoli repoTitoli = new CrudTitoli(connectionString);
            ContattiView view = new ContattiView();

            bool running = true;

            while (running)
            {
                view.DisplayMenu();
                int scelta = view.GetChoice();

                switch (scelta)
                {
                    case 1:
                        var contatti = repoContatti.FindAll();
                        view.DisplayContatti(contatti);
                        break;
                    case 2:
                        var nuovo = view.GetNewContattoData();
                        view.DisplayTitoliStudio(repoTitoli.FindAll());
                        if (repoTitoli.GetById(nuovo.TdS) == null)
                        {
                            view.DisplayError("ID titolo non valido.");
                            break;
                        }
                        repoContatti.CreaContatto(nuovo);
                        view.DisplaySuccess("Contatto inserito.");
                        break;
                    case 3:
                        var allC = repoContatti.FindAll();
                        view.DisplayContatti(allC);
                        int modId = view.GetChoice();
                        var contattoMod = repoContatti.GetById(modId);
                        if (contattoMod == null) { view.DisplayError("ID non trovato."); break; }
                        contattoMod = view.NuovoContatto(contattoMod);
                        if (repoTitoli.GetById(contattoMod.TdS) == null) { view.DisplayError("ID titolo non valido."); break; }
                        repoContatti.ModificaContatto(contattoMod);
                        view.DisplaySuccess("Contatto modificato.");
                        break;
                    case 4:
                        var allD = repoContatti.FindAll();
                        view.DisplayContatti(allD);
                        int delId = view.GetChoice();
                        repoContatti.EliminaContatto(delId);
                        view.DisplaySuccess("Contatto eliminato.");
                        break;
                    case 5:
                        view.DisplayTitoliStudio(repoTitoli.FindAll());
                        break;
                    case 6:
                        var nuovoTitolo = view.GetNewTitolo();
                        repoTitoli.CreaTitolo(nuovoTitolo);
                        view.DisplaySuccess("Titolo inserito.");
                        break;
                    case 7:
                        var titoli = repoTitoli.FindAll();
                        view.DisplayTitoliStudio(titoli);
                        int modTId = view.GetChoice();
                        var titoloMod = repoTitoli.GetById(modTId);
                        if (titoloMod == null) { view.DisplayError("ID non trovato."); break; }
                        titoloMod.Titolo = view.LeggiStringa($"Titolo ({titoloMod.Titolo})");
                        repoTitoli.ModificaTitolo(titoloMod);
                        view.DisplaySuccess("Titolo modificato.");
                        break;
                    case 8:
                        var titoliDel = repoTitoli.FindAll();
                        view.DisplayTitoliStudio(titoliDel);
                        int delTId = view.GetChoice();
                        repoTitoli.EliminaTitolo(delTId);
                        view.DisplaySuccess("Titolo eliminato.");
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
