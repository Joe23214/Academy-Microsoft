using System;
using System.Linq;

namespace ConsoleApp1.Views
{
    internal class MenuView
    {
        private UniversitàController controller;

        public MenuView(UniversitàController ctrl)
        {
            controller = ctrl;
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Aggiungi Professore");
                Console.WriteLine("2. Aggiungi Corso");
                Console.WriteLine("3. Assegna Professore a Corso");
                Console.WriteLine("4. Aggiungi Studente");
                Console.WriteLine("5. Aggiungi Voto");
                Console.WriteLine("6. Visualizza tutti gli studenti");
                Console.WriteLine("7. Studente con media più alta");
                Console.WriteLine("8. Cerca studente per matricola");
                Console.WriteLine("9. Stampa libretto studente");
                Console.WriteLine("10. Esci");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": AggiungiProfessore(); break;
                    case "2": AggiungiCorso(); break;
                    case "3": AssegnaProfessoreACorso(); break;
                    case "4": AggiungiStudente(); break;
                    case "5": AggiungiVoto(); break;
                    case "6": VisualizzaStudenti(); break;
                    case "7": MediaPiuAlta(); break;
                    case "8": CercaStudente(); break;
                    case "9": StampaLibretto(); break;
                    case "10": exit = true; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void AggiungiProfessore()
        {
            Console.Write("Nome: "); string n = Console.ReadLine();
            Console.Write("Cognome: "); string c = Console.ReadLine();
            Console.Write("ID: "); string id = Console.ReadLine();
            Console.Write("Materia: "); string m = Console.ReadLine();

            if (controller.AggiungiProfessore(n, c, id, m))
                Console.WriteLine("Professore aggiunto.");
            else
                Console.WriteLine("Errore: ID già esistente.");
        }

        private void AggiungiCorso()
        {
            Console.Write("Codice corso: "); string cod = Console.ReadLine();
            Console.Write("Nome corso: "); string nome = Console.ReadLine();

            if (controller.AggiungiCorso(cod, nome))
            {
                var corso = controller.CercaCorso(cod);

                Console.Write("Quante materie vuoi aggiungere al corso? ");
                if (int.TryParse(Console.ReadLine(), out int nMaterie))
                {
                    for (int i = 0; i < nMaterie; i++)
                    {
                        Console.Write($"Materia {i + 1}: ");
                        string mat = Console.ReadLine();
                        corso.AggiungiMateria(mat);
                    }
                }

                Console.WriteLine("Corso aggiunto.");
            }
            else
                Console.WriteLine("Errore: codice corso già esistente.");
        }


        private void AssegnaProfessoreACorso()
        {
            Console.Write("ID Professore: "); string id = Console.ReadLine();
            Console.Write("Codice Corso: "); string cod = Console.ReadLine();

            if (controller.AssegnaProfessoreACorso(id, cod))
                Console.WriteLine("Professore assegnato al corso.");
            else
                Console.WriteLine("Errore: ID o codice corso non valido.");
        }

        private void AggiungiStudente()
        {
            Console.Write("Nome: "); string n = Console.ReadLine();
            Console.Write("Cognome: "); string c = Console.ReadLine();
            Console.Write("Matricola: "); string m = Console.ReadLine();

            Console.WriteLine("Corsi disponibili:");
            foreach (var corso in controller.GetAllCorsi())
                Console.WriteLine($"{corso.Codice}: {corso.Nome}");

            Console.Write("Codice corso: "); string codCorso = Console.ReadLine();

            if (controller.AggiungiStudente(n, c, m, codCorso))
                Console.WriteLine("Studente aggiunto.");
            else
                Console.WriteLine("Errore: matricola esistente o corso non valido.");
        }

        private void AggiungiVoto()
        {
            Console.Write("Matricola studente: "); string m = Console.ReadLine();
            Console.Write("Materia: "); string mat = Console.ReadLine();
            Console.Write("Voto (0-30): ");
            if (!int.TryParse(Console.ReadLine(), out int v) || v < 0 || v > 30)
            {
                Console.WriteLine("Voto non valido.");
                return;
            }

            if (controller.AggiungiVoto(m, mat, v))
                Console.WriteLine("Voto aggiunto.");
            else
                Console.WriteLine("Errore: studente non trovato o materia non valida.");
        }

        private void VisualizzaStudenti()
        {
            foreach (var s in controller.GetAllStudenti())
                Console.WriteLine(s);
        }

        private void MediaPiuAlta()
        {
            var s = controller.StudenteMediaPiuAlta();
            Console.WriteLine(s != null ? $"Top: {s}" : "Nessuno studente.");
        }

        private void CercaStudente()
        {
            Console.Write("Inserisci matricola: ");
            string m = Console.ReadLine();
            var studente = controller.CercaStudente(m);
            if (studente != null)
                Console.WriteLine(studente);
            else
                Console.WriteLine("Studente non trovato.");
        }

        private void StampaLibretto()
        {
            Console.Write("Inserisci matricola studente: ");
            string m = Console.ReadLine();
            var studente = controller.CercaStudente(m);

            if (studente != null)
                studente.StampaLibretto();
            else
                Console.WriteLine("Studente non trovato.");
        }
    }
}
