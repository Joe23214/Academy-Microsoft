using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentiController controller = new StudentiController();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Aggiungi studente");
                Console.WriteLine("2. Cerca studente per matricola");
                Console.WriteLine("3. Aggiungi voto a studente");
                Console.WriteLine("4. Visualizza tutti");
                Console.WriteLine("5. Studente con media più alta");
                Console.WriteLine("6. Esci");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();
                Console.WriteLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiStudente(controller);
                        break;

                    case "2":
                        Cerca(controller);
                        break;

                    case "3":
                        AggiungiVoto(controller);
                        break;

                    case "4":
                        VisualizzaTutti(controller);
                        break;

                    case "5":
                        MediaPiuAlta(controller);
                        break;

                    case "6":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }

        static void AggiungiStudente(StudentiController c)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Matricola: ");
            string matricola = Console.ReadLine();

            if (c.AggiungiStudente(nome, cognome, matricola))
                Console.WriteLine("Studente aggiunto.");
            else
                Console.WriteLine("Errore: matricola già esistente.");
        }

        static void Cerca(StudentiController c)
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine();

            Studente s = c.Cerca(m);
            Console.WriteLine(s != null ? s.ToString() : "Studente non trovato.");
        }

        static void AggiungiVoto(StudentiController c)
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine();
            Console.Write("Voto: ");
            int voto = int.Parse(Console.ReadLine());

            if (voto < 0 || voto > 30)
            {
                Console.WriteLine("Voto non valido, impostato a 0.");
                voto = 0;
            }

            if (c.AggiungiVoto(m, voto))
                Console.WriteLine("Voto aggiunto.");
            else
                Console.WriteLine("Studente non trovato.");
        }

        static void VisualizzaTutti(StudentiController c)
        {
            Console.WriteLine("--- ELENCO STUDENTI ---");
            foreach (var s in c.GetAll())
                Console.WriteLine(s);
        }

        static void MediaPiuAlta(StudentiController c)
        {
            Studente top = c.MediaPiuAlta();
            if (top != null)
                Console.WriteLine("Studente con media più alta:\n" + top);
            else
                Console.WriteLine("Nessuno studente presente.");
        }

    }

}