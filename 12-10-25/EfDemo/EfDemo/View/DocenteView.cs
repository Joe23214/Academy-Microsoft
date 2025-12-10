using EfDemo.Controller;
using EfDemo.Models;
using System;
using System.Linq;

namespace EfDemo.View
{
    public class DocenteView
    {
        private readonly DocenteController docenteController = new();
        private readonly CorsoController corsoController = new();

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU DOCENTI ===");
                Console.WriteLine("1) Inserisci docente");
                Console.WriteLine("2) Visualizza docenti");
                Console.WriteLine("3) Modifica docente");
                Console.WriteLine("4) Elimina docente");
                Console.WriteLine("5) Assegna corso a docente");
                Console.WriteLine("6) Rimuovi corso da docente");
                Console.WriteLine("0) Torna al menu principale");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": InserisciDocente(); break;
                    case "2": VisualizzaDocenti(); break;
                    case "3": ModificaDocente(); break;
                    case "4": EliminaDocente(); break;
                    case "5": AssegnaCorso(); break;
                    case "6": RimuoviCorso(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void InserisciDocente()
        {
            Console.Write("Nome docente: ");
            string nome = Console.ReadLine();

            var docente = new Docente { Name = nome, corsi = new List<Corso>() };
            docenteController.InserisciDocente(docente);

            Console.WriteLine("Docente inserito!");
        }

        private void VisualizzaDocenti()
        {
            var docenti = docenteController.GetDocenti().ToList();

            Console.WriteLine("\n=== LISTA DOCENTI ===");
            foreach (var d in docenti)
            {
                Console.WriteLine($"ID: {d.Id}, Nome: {d.Name}");
                Console.WriteLine("  Corsi: " + (d.corsi.Any() ? string.Join(", ", d.corsi.Select(c => c.Titolo)) : "Nessun corso assegnato"));
            }
        }

        private void ModificaDocente()
        {
            VisualizzaDocenti();
            Console.Write("ID docente da modificare: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var docente = docenteController.GetDocenteById(id);
            if (docente == null) {
                Console.WriteLine("Docente non trovato.");
                return; }

            Console.Write("Nuovo nome: ");
            docente.Name = Console.ReadLine();

            docenteController.ModificaDocente(docente);
            Console.WriteLine("Docente modificato!");
        }

        private void EliminaDocente()
        {
            VisualizzaDocenti();
            Console.Write("ID docente da eliminare: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var docente = docenteController.GetDocenteById(id);
            if (docente == null) {
                Console.WriteLine("Docente non trovato.");
                return; }

            docenteController.EliminaDocente(docente);
            Console.WriteLine("Docente eliminato!");
        }

        private void AssegnaCorso()
        {
            VisualizzaDocenti();
            Console.Write("ID docente: ");
            if (!int.TryParse(Console.ReadLine(), out int idDocente))
                return;

            var docente = docenteController.GetDocenteById(idDocente);
            if (docente == null) { Console.WriteLine("Docente non trovato.");
                return; }

            var corsi = corsoController.GetCorsi().ToList();
            if (corsi.Count() == 0)
            {
                Console.WriteLine("Nessun corso in sistema.");
                return;
            }
            Console.WriteLine("\n=== CORSI DISPONIBILI ===");
            foreach (var c in corsi) 
                Console.WriteLine($"{c.Id}) {c.Titolo}");

            Console.Write("ID corso da assegnare: ");
            if (!int.TryParse(Console.ReadLine(), out int idCorso))
                return;

            var corso = corsoController.GetCorsoById(idCorso);
            if (corso == null) {
                Console.WriteLine("Corso non trovato.");
                return; }

            docenteController.AssegnaCorso(docente, corso);
            Console.WriteLine("Corso assegnato!");
        }

        private void RimuoviCorso()
        {
            VisualizzaDocenti();
            Console.Write("ID docente: ");
            if (!int.TryParse(Console.ReadLine(), out int idDocente))
                return;

            var docente = docenteController.GetDocenteById(idDocente);
            if (docente == null) { Console.WriteLine("Docente non trovato."); 
                return; }

            if (!docente.corsi.Any()) { Console.WriteLine("Il docente non ha corsi.");
                return; }

            Console.WriteLine("\n=== CORSI ASSEGNATI ===");
            foreach (var c in docente.corsi) 
                Console.WriteLine($"{c.Id}) {c.Titolo}");

            Console.Write("ID corso da rimuovere: ");
            if (!int.TryParse(Console.ReadLine(), out int idCorso))
                return;

            var corso = docente.corsi.FirstOrDefault(c => c.Id == idCorso);
            if (corso == null) { Console.WriteLine("Corso non trovato.");
                return; }

            docenteController.RimuoviCorso(docente, corso);
            Console.WriteLine("Corso rimosso!");
        }
    }
}
