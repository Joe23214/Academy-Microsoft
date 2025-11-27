using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class MenuView
    {
        private StudentiController controller;

        public MenuView(StudentiController controller)
        {
            this.controller = controller;
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Aggiungi studente");
                Console.WriteLine("2. Cerca studente per matricola");
                Console.WriteLine("3. Aggiungi voto");
                Console.WriteLine("4. Visualizza tutti");
                Console.WriteLine("5. Media più alta");
                Console.WriteLine("6. Esci");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1": AggiungiStudente(); break;
                    case "2": CercaStudente(); break;
                    case "3": AggiungiVoto(); break;
                    case "4": VisualizzaTutti(); break;
                    case "5": MediaPiuAlta(); break;
                    case "6": exit = true; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void AggiungiStudente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Matricola: ");
            string matricola = Console.ReadLine();

            if (controller.AggiungiStudente(nome, cognome, matricola))
                Console.WriteLine("Studente aggiunto.");
            else
                Console.WriteLine("Errore: matricola esistente.");
        }

        private void CercaStudente()
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine();

            var s = controller.Cerca(m);
            Console.WriteLine(s != null ? s.ToString() : "Studente non trovato.");
        }

        private void AggiungiVoto()
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine();
            Console.Write("Voto (0–30): ");
            int voto = int.Parse(Console.ReadLine());

            if (!controller.AggiungiVoto(m, voto))
                Console.WriteLine("Studente non trovato.");
            else
                Console.WriteLine("Voto aggiunto.");
        }

        private void VisualizzaTutti()
        {
            Console.WriteLine("--- Studenti ---");
            foreach (var s in controller.GetAll())
                Console.WriteLine(s);
        }

        private void MediaPiuAlta()
        {
            var s = controller.MediaPiuAlta();
            Console.WriteLine(s != null ? $"Top: {s}" : "Nessuno studente.");
        }
    }
}

