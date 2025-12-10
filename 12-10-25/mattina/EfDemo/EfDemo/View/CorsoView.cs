using EfDemo.Controller;
using EfDemo.Models;
using System;
using System.Linq;

namespace EfDemo.View
{
    public class CorsoView
    {
        private readonly CorsoController corsoController = new();
        private readonly DocenteController docenteController = new();
        private readonly StudenteController studenteController = new();

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU CORSI ===");
                Console.WriteLine("1) Inserisci corso");
                Console.WriteLine("2) Visualizza corsi");
                Console.WriteLine("3) Modifica corso");
                Console.WriteLine("4) Elimina corso");
                Console.WriteLine("5) Assegna docente a corso");
                Console.WriteLine("6) Assegna studente a corso");
                Console.WriteLine("0) Torna al menu principale");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": InserisciCorso(); break;
                    case "2": VisualizzaCorsi(); break;
                    case "3": ModificaCorso(); break;
                    case "4": EliminaCorso(); break;
                    case "5": AssegnaDocente(); break;
                    case "6": AssegnaStudente(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void InserisciCorso()
        {
            Console.Write("Titolo corso: "); string titolo = Console.ReadLine();
            Console.Write("Codice corso: "); string codice = Console.ReadLine();

            var corso = new Corso { Titolo = titolo, codiceCorso = codice };
            corsoController.InserisciCorso(corso);

            Console.WriteLine("Corso inserito!");
        }

        private void VisualizzaCorsi()
        {
            var corsi = corsoController.GetCorsi().ToList();

            Console.WriteLine("\n=== LISTA CORSI ===");
            foreach (var c in corsi)
            {
                Console.WriteLine($"ID: {c.Id}, {c.Titolo} ({c.codiceCorso})");
                Console.WriteLine("  Docenti: " + (c.Docenti.Any() ? string.Join(", ", c.Docenti.Select(d => d.Name)) : "Nessuno"));
                Console.WriteLine("  Studenti: " + (c.studenti.Any() ? string.Join(", ", c.studenti.Select(s => s.Nome + " " + s.Cognome)) : "Nessuno"));
            }
        }

        private void ModificaCorso()
        {
            VisualizzaCorsi();
            Console.Write("ID corso da modificare: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) 
                return;

            var corso = corsoController.GetCorsoById(id);
            if (corso == null) {
                Console.WriteLine("Corso non trovato.");
                return; }

            Console.Write("Nuovo titolo: ");
            corso.Titolo = Console.ReadLine();
            Console.Write("Nuovo codice: "); 
            corso.codiceCorso = Console.ReadLine();

            corsoController.ModificaCorso(corso);
            Console.WriteLine("Corso modificato!");
        }

        private void EliminaCorso()
        {
            VisualizzaCorsi();
            Console.Write("ID corso da eliminare: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var corso = corsoController.GetCorsoById(id);
            if (corso == null) {
                Console.WriteLine("Corso non trovato.");
                return; }

            corsoController.EliminaCorso(corso);
            Console.WriteLine("Corso eliminato!");
        }

        private void AssegnaDocente()
        {
            VisualizzaCorsi();
            Console.Write("ID corso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCorso)) 
                return;

            var corso = corsoController.GetCorsoById(idCorso);
            if (corso == null) { 
                Console.WriteLine("Corso non trovato.");
                return; }

            var docenti = docenteController.GetDocenti().ToList();
            Console.WriteLine("\n=== DOCENTI DISPONIBILI ===");
            foreach (var d in docenti)
                Console.WriteLine($"{d.Id}) {d.Name}");

            Console.Write("ID docente da assegnare: ");
            if (!int.TryParse(Console.ReadLine(), out int idDocente)) 
                return;

            var docente = docenteController.GetDocenteById(idDocente);
            if (docente == null) {
                Console.WriteLine("Docente non trovato.");
                return; }

            corsoController.AssegnaDocente(corso, docente);
            Console.WriteLine("Docente assegnato!");
        }

        private void AssegnaStudente()
        {
            VisualizzaCorsi();
            Console.Write("ID corso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCorso))
                return;

            var corso = corsoController.GetCorsoById(idCorso);
            if (corso == null) { 
                Console.WriteLine("Corso non trovato.");
                return; }

            var studenti = studenteController.GetStudenti().ToList();
            Console.WriteLine("\n=== STUDENTI DISPONIBILI ===");
            foreach (var s in studenti)
                Console.WriteLine($"{s.Id}) {s.Nome} {s.Cognome}");

            Console.Write("ID studente da assegnare: ");
            if (!int.TryParse(Console.ReadLine(), out int idStudente)) 
                return;

            var studente = studenteController.GetStudenteById(idStudente);
            if (studente == null) {
                Console.WriteLine("Studente non trovato.");
                return; }

            corsoController.AssegnaStudente(corso, studente);
            Console.WriteLine("Studente assegnato!");
        }
    }
}
