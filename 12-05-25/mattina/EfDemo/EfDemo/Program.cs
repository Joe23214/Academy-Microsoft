using EfDemo;
using EfDemo.Models;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new ScuolaContext();
            /*
            // CREATE
            db.Studenti.Add(new Studente { Nome = "Mario", Eta = 22 });
            db.SaveChanges();
            // READ
            var elenco = db.Studenti.ToList();
            foreach (var s in elenco)
                Console.WriteLine($"{s.Id} - {s.Nome} - {s.Eta}");
            // UPDATE
            var stud = db.Studenti.First();
            stud.Eta = 23;
            db.SaveChanges();
            // DELETE
            db.Studenti.Remove(stud);
            db.SaveChanges();
            Console.WriteLine("Operazioni completate.");
            */

            //Creare
            //Studenti si riferisce al oggetto dbSet che setta il db e creato dall'entity framework direttamente
            /*
            db.Studenti.Add(new Studente { Nome = "Nome", Eta = 25 });
            db.Studenti.Add(new Studente { Nome = "Nome1", Eta = 26 });
            db.Studenti.Add(new Studente { Nome = "Nome2", Eta = 27 });
            db.SaveChanges();
            

            //Visualizzare
            var lista = db.Studenti.ToList();
            foreach (var item in lista) { 
                Console.WriteLine($"Nome: {item.Nome} età: {item.Eta}");
            }

            
            //modficiare
            var studente = db.Studenti.First();
            studente.Nome = "Nome modificato";
            studente.Eta = 1;
            db.SaveChanges();

            */
            //Visualizzare
            var lista = db.Studenti.ToList();
            foreach (var item in lista)
            {
                Console.WriteLine($"ID: {item.Id} Nome: {item.Nome} età: {item.Eta}");
            }
            /*
            //modificare
            Console.WriteLine("inserisci l'id dello studente da modificare:");
            int id = int.Parse(Console.ReadLine());

            foreach (var item in lista)
            {
                if (item.Id == id) {
                    Console.WriteLine("Scelgi il nuovo nome: ");
                    item.Nome = Console.ReadLine();
                    Console.WriteLine("Scelgi la nuova età: ");
                    item.Eta = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Studente modificato! attributi modificati -> Nome: {item.Nome} età: {item.Eta}");
                    db.SaveChanges();

                }
               
            }

            //modifica 2
           
             var lista2 = db.Studenti.ToList();
            foreach (var item in lista2)
            {
                Console.WriteLine($"ID: {item.Id} Nome: {item.Nome} età: {item.Eta}");
            }
            Console.WriteLine("inserisci l'id dello studente da modificare:");
            Studente x = db.Studenti.Find(id);

            Console.WriteLine("Scelgi il nuovo nome: ");
            x.Nome = Console.ReadLine();
            Console.WriteLine("Scelgi la nuova età: ");
            x.Eta = int.Parse(Console.ReadLine());
            Console.WriteLine($"Studente modificato! attributi modificati -> Nome: {x.Nome} età: {x.Eta}");

            db.SaveChanges();
            

           //eliminare
            Console.WriteLine("inserisci l'id dello studente da modificare:");
            int id = int.Parse(Console.ReadLine());
            Studente x1 = db.Studenti.Find(id);
            db.Studenti.Remove(x1);
            db.SaveChanges();

            obbiettivo giorno 10:
            PATTERN MVC CON ENTITY FRAMEWORK (CON REPOSITORY)
            MODELLI:
            -STUDENTE
            -DOCENTE
            -CORSO/FACOLTA
            
            x 05 pomeriggio:
            imparare a usare linq
            inserire nel progetto lista di cose fatte con linq



            //Inserimento nuovo campo in studenti che abbiamo
            Console.WriteLine("Inserisci i cognomi:");
            var lista2 = db.Studenti.ToList();
            foreach (var item in lista2)
            {
                Console.WriteLine("Inserisci nuovo congome:");
                item.Cognome = Console.ReadLine();
            }
            db.SaveChanges();
            */
            Docente Docente = new Docente();
            Console.WriteLine("___CREAZIONR DOCENTE___");
            Console.WriteLine("Inserisci il nome docente:");
            Docente.Name = Console.ReadLine();
            Console.WriteLine("Inserisci il nome docente:");
            Docente.Materia = Console.ReadLine();
            db.SaveChanges();



        }
    }
}