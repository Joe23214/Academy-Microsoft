using EfDemo.Controller;
using EfDemo.Models;
using System;
using System.Linq;

namespace EfDemo.View
{
    public class StudenteView
    {
        private readonly StudenteController studenteController = new();
        private readonly CorsoController corsoController = new();

        public void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU STUDENTI ===");
                Console.WriteLine("1) Inserisci studente");
                Console.WriteLine("2) Visualizza studenti");
                Console.WriteLine("3) Modifica studente");
                Console.WriteLine("4) Elimina studente");
                Console.WriteLine("5) Assegna corso a studente");
                Console.WriteLine("6) Rimuovi corso da studente");
                Console.WriteLine("0) Torna al menu principale");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": InserisciStudente(); break;
                    case "2": VisualizzaStudenti(); break;
                    case "3": ModificaStudente(); break;
                    case "4": EliminaStudente(); break;
                    case "5": AssegnaCorso(); break;
                    case "6": RimuoviCorso(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void InserisciStudente()
        {
            Console.Write("Nome: "); 
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Età: "); 
            int eta = int.Parse(Console.ReadLine());
            Console.Write("Matricola: "); 
            string matricola = Console.ReadLine();

            var studente = new Studente
            {
                Nome = nome,
                Cognome = cognome,
                Eta = eta,
                Matricola = matricola
            };

            studenteController.InserisciStudente(studente);
            Console.WriteLine("Studente inserito!");
        }

        private void VisualizzaStudenti()
        {
            var studenti = studenteController.GetStudenti().ToList();

            Console.WriteLine("\n=== LISTA STUDENTI ===");
            foreach (var s in studenti)
            {
                Console.WriteLine($"ID: {s.Id}, {s.Nome} {s.Cognome}, Età: {s.Eta}, Matricola: {s.Matricola}");
                Console.WriteLine("  Corsi: " + (s.Corsi.Any() ? string.Join(", ", s.Corsi.Select(c => c.Titolo)) : "Nessun corso assegnato"));
            }
        }

        private void ModificaStudente()
        {
            VisualizzaStudenti();
            Console.Write("ID studente da modificare: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var studente = studenteController.GetStudenteById(id);
            if (studente == null) {
                Console.WriteLine("Studente non trovato.");
                return; }

            Console.Write("Nuovo nome: ");
            studente.Nome = Console.ReadLine();
            Console.Write("Nuovo cognome: ");
            studente.Cognome = Console.ReadLine();
            Console.Write("Nuova età: "); 
            studente.Eta = int.Parse(Console.ReadLine());
            Console.Write("Nuova matricola: ");
            studente.Matricola = Console.ReadLine();

            studenteController.ModificaStudente(studente);
            Console.WriteLine("Studente modificato!");
        }

        private void EliminaStudente()
        {
            VisualizzaStudenti();
            Console.Write("ID studente da eliminare: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var studente = studenteController.GetStudenteById(id);
            if (studente == null) { 
                Console.WriteLine("Studente non trovato.");
                return; }

            studenteController.EliminaStudente(studente);
            Console.WriteLine("Studente eliminato!");
        }

        private void AssegnaCorso()
        {
            VisualizzaStudenti();
            Console.Write("ID studente: ");
            if (!int.TryParse(Console.ReadLine(), out int idStudente)) 
                return;

            var studente = studenteController.GetStudenteById(idStudente);
            if (studente == null) {
                Console.WriteLine("Studente non trovato.");
                return; }

            var corsi = new List<Corso>();
            try
            {
                corsi = corsoController.GetCorsi()?.ToList() ?? new List<Corso>();
            }
            catch
            {
                corsi = new List<Corso>();
            }

            if (corsi.Count == 0)
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

            var corso = corsi.FirstOrDefault(c => c.Id == idCorso);
            if (corso == null) { 
                Console.WriteLine("Corso non trovato.");
                return; }

            studenteController.AssegnaCorso(studente, corso);
            Console.WriteLine("Corso assegnato!");
        }

        private void RimuoviCorso()
        {
            VisualizzaStudenti();
            Console.Write("ID studente: ");
            if (!int.TryParse(Console.ReadLine(), out int idStudente))
                return;

            var studente = studenteController.GetStudenteById(idStudente);
            if (studente == null) { 
                Console.WriteLine("Studente non trovato."); 
                return; }

            if (!studente.Corsi.Any()) { 
                Console.WriteLine("Lo studente non ha corsi."); 
                return; }

            Console.WriteLine("\n=== CORSI ASSEGNATI ===");
            foreach (var c in studente.Corsi) 
                Console.WriteLine($"{c.Id}) {c.Titolo}");

            Console.Write("ID corso da rimuovere: ");
            if (!int.TryParse(Console.ReadLine(), out int idCorso))
                return;

            var corso = studente.Corsi.FirstOrDefault(c => c.Id == idCorso);
            if (corso == null) {
                Console.WriteLine("Corso non trovato.");
                return; }

            studenteController.RimuoviCorso(studente, corso);
            Console.WriteLine("Corso rimosso!");
        }
    }
}
