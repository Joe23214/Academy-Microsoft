using EfDemo.Controller;
using EfDemo.Models;
using System;
using System.Linq;

namespace EfDemo.View
{
    public class StudenteView
    {
        public void ShowMenuStudente()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU STUDENTI ===");
                Console.WriteLine("1) Inserisci uno studente");
                Console.WriteLine("2) Visualizza tutti gli studenti");
                Console.WriteLine("3) Modifica uno studente");
                Console.WriteLine("4) Elimina uno studente");
                Console.WriteLine("0) Torna al menu principale");
                Console.Write("Scelta: ");

                int scelta = int.Parse(Console.ReadLine());

                switch (scelta)
                {
                    case 1: InserisciStudente(); break;
                    case 2: VisualizzaStudenti(); break;
                    case 3: ModificaStudente(); break;
                    case 4: EliminaStudente(); break;
                    case 0: running = false; break;
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

            Console.Write("Id Corso: ");
            int idCorso = int.Parse(Console.ReadLine());

            var studente = new Studente
            {
                Nome = nome,
                Cognome = cognome,
                Eta = eta,
                Matricola = matricola,
                IdCorso = idCorso
            };

            var controller = new StudenteController();
            controller.InserisciStudente(studente);

            Console.WriteLine("Studente inserito correttamente!");
        }

        private void VisualizzaStudenti()
        {
            var controller = new StudenteController();
            var studenti = controller.GetStudenti().ToList();

            Console.WriteLine("\nLista studenti ordinata:");
            foreach (var s in studenti)
            {
                Console.WriteLine(
                    $"ID: {s.Id}, Nome: {s.Nome}, Cognome: {s.Cognome}, Età: {s.Eta}, Matricola: {s.Matricola}, IdCorso: {s.IdCorso}");
            }
        }

        private void ModificaStudente()
        {
            VisualizzaStudenti();

            Console.Write("Inserisci ID da modificare: ");
            int id = int.Parse(Console.ReadLine());

            var controller = new StudenteController();
            var stud = controller.GetStudenteById(id);

            if (stud == null)
            {
                Console.WriteLine("Studente non trovato!");
                return;
            }

            Console.Write("Nuovo Nome: ");
            stud.Nome = Console.ReadLine();

            Console.Write("Nuovo Cognome: ");
            stud.Cognome = Console.ReadLine();

            Console.Write("Nuova Età: ");
            stud.Eta = int.Parse(Console.ReadLine());

            Console.Write("Nuova Matricola: ");
            stud.Matricola = Console.ReadLine();

            Console.Write("Nuovo IdCorso: ");
            stud.IdCorso = int.Parse(Console.ReadLine());

            controller.ModificaStudente(stud);
            Console.WriteLine("Studente modificato correttamente!");
        }

        private void EliminaStudente()
        {
            VisualizzaStudenti();

            Console.Write("Inserisci ID da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            var controller = new StudenteController();
            controller.EliminaStudente(id);

            Console.WriteLine("Studente eliminato correttamente!");
        }
    }
}
