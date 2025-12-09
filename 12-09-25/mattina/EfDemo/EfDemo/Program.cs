using EfDemo.Data;
using EfDemo.Models;
using EfDemo.View;
using System;
using System.Linq;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new MenuView().Show();
        }
        /*
        static void Main(string[] args)
        {
            
            using var db = new ScuolaContext();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nInserisci la scelta tra quelle presenti in menù:");
                Console.WriteLine("1) Inserisci uno studente");
                Console.WriteLine("2) Visualizza tutti gli studenti");
                Console.WriteLine("3) Modifica uno studente");
                Console.WriteLine("4) Elimina uno studente");
                Console.WriteLine("5) Inserisci un docente");
                Console.WriteLine("6) Visualizza tutti i docenti");
                Console.WriteLine("7) Modifica un docente");
                Console.WriteLine("8) Elimina un docente");
                Console.WriteLine("0) Esci");
                Console.Write("Scelta: ");

                int scelta = int.Parse(Console.ReadLine());

                switch (scelta)
                {
                    case 1: InserisciStudente(db); break;
                    case 2: VisualizzaStudenti(db); break;
                    case 3: ModificaStudente(db); break;
                    case 4: EliminaStudente(db); break;
                    case 5: InserisciDocente(db); break;
                    case 6: VisualizzaDocenti(db); break;
                    case 7: ModificaDocente(db); break;
                    case 8: EliminaDocente(db); break;
                    case 0: running = false; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        static void InserisciStudente(ScuolaContext db)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Età: ");
            int eta = int.Parse(Console.ReadLine());

            var studente = new Studente { Nome = nome, Cognome = cognome, Eta = eta };
            db.Studenti.Add(studente); //Metodo che fa insert
            db.SaveChanges();  //metodo che salva le operazioni fatte a db, fondamentale a fine istruzione
            Console.WriteLine("Studente inserito correttamente!");
        }

        static void VisualizzaStudenti(ScuolaContext db)
        {

            var studenti = db.Studenti
                             .OrderBy(s => s.Cognome) //ordina gli elementi in base al parametro passato
                             .Select(s => new { s.Id, s.Nome, s.Cognome, s.Eta }) //seleziona i campi interessati passati come parametro
                             .ToList(); //ritorna il risultato in una lista

            Console.WriteLine("\nLista studenti ordinata:");
            foreach (var s in studenti)
            {
                Console.WriteLine($"ID: {s.Id}, Nome: {s.Nome}, Cognome: {s.Cognome}, Età: {s.Eta}");
            }
        }

        static void ModificaStudente(ScuolaContext db)
        {
            var studenti = db.Studenti.ToList();
            foreach (var s in studenti)
            {
                Console.WriteLine($"ID: {s.Id}, Nome: {s.Nome}, Cognome: {s.Cognome}, Età: {s.Eta}");
            }

            Console.WriteLine("\nLista studenti ordinata:");
            Console.Write("Inserisci l'ID dello studente da modificare: ");
            int id = int.Parse(Console.ReadLine());

            
            var studente = db.Studenti.SingleOrDefault(s => s.Id == id); //restituisce l'unico elemento che soddisfa la condizione o restituisce null
            if (studente == null)
            {
                Console.WriteLine("Studente non trovato!");
                return;
            }

            Console.Write("Nuovo Nome: ");
            studente.Nome = Console.ReadLine();
            Console.Write("Nuovo Cognome: ");
            studente.Cognome = Console.ReadLine();
            Console.Write("Nuova Età: ");
            studente.Eta = int.Parse(Console.ReadLine());

            db.SaveChanges();
            Console.WriteLine("Studente modificato correttamente!");
        }

        static void EliminaStudente(ScuolaContext db)
        {

            var studenti = db.Studenti.ToList();
            foreach (var s in studenti)
            {
                Console.WriteLine($"ID: {s.Id}, Nome: {s.Nome}, Cognome: {s.Cognome}, Età: {s.Eta}");
            }

            Console.Write("Inserisci l'ID dello studente da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            
            var studente = db.Studenti.Where(s => s.Id == id).FirstOrDefault(); //where: filtra gli elementi in base a una condizione,
                                                                                //firstOrDefault restituisce il primo elemento che soddisfa la condizione o null
            if (studente == null)
            {
                Console.WriteLine("Studente non trovato!");
                return;
            }

            db.Studenti.Remove(studente); //rimuove l'entità
            db.SaveChanges(); 
            Console.WriteLine("Studente eliminato correttamente!");
        }


        static void InserisciDocente(ScuolaContext db)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            var docente = new Docente { Name = nome, Materia = materia };
            db.Docenti.Add(docente);
            db.SaveChanges();
            Console.WriteLine("Docente inserito correttamente!");
        }

        static void VisualizzaDocenti(ScuolaContext db)
        {
      
            var docenti = db.Docenti
                            .OrderBy(d => d.Name)
                            .Select(d => new { d.Id, d.Name, d.Materia })
                            .ToList();

            Console.WriteLine("\nLista docenti ordinata:");
            foreach (var d in docenti)
            {
                Console.WriteLine($"ID: {d.Id}, Nome: {d.Name}, Materia: {d.Materia}");
            }
        }

        static void ModificaDocente(ScuolaContext db)
        {
            var docenti = db.Docenti.ToList();

            foreach (var d in docenti)
            {
                Console.WriteLine($"ID: {d.Id}, Nome: {d.Name}, Materia: {d.Materia}");
            }
            Console.Write("Inserisci l'ID del docente da modificare: ");
            int id = int.Parse(Console.ReadLine());

            if (!db.Docenti.Any(d => d.Id == id)) //restituisce true se c'è almeno un elemento che rispetta la condizione
            {
                Console.WriteLine("Docente non trovato!");
                return;
            }

            var docente = db.Docenti.Where(d => d.Id == id).FirstOrDefault();

            Console.Write("Nuovo Nome: ");
            docente.Name = Console.ReadLine();
            Console.Write("Nuova Materia: ");
            docente.Materia = Console.ReadLine();

            db.SaveChanges();
            Console.WriteLine("Docente modificato correttamente!");
        }

        static void EliminaDocente(ScuolaContext db)
        {
            var docenti = db.Docenti.ToList();

            foreach (var d in docenti)
            {
                Console.WriteLine($"ID: {d.Id}, Nome: {d.Name}, Materia: {d.Materia}");
            }
            Console.Write("Inserisci l'ID del docente da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            if (db.Docenti.Count(d => d.Id == id) == 0) //conta gli elementi che soddisfano il parametro
            {
                Console.WriteLine("Docente non trovato!");
                return;
            }

            var docente = db.Docenti.Where(d => d.Id == id).FirstOrDefault();
            db.Docenti.Remove(docente);
            db.SaveChanges();
            Console.WriteLine("Docente eliminato correttamente!");
        }
            */
    }
}
