using EfDemo.Controller;
using EfDemo.Models;
using System;
using System.Linq;

namespace EfDemo.View
{
    public class DocenteView
    {
        public void ShowMenuDocente()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU DOCENTI ===");
                Console.WriteLine("1) Inserisci un docente");
                Console.WriteLine("2) Visualizza tutti i docenti");
                Console.WriteLine("3) Modifica un docente");
                Console.WriteLine("4) Elimina un docente");
                Console.WriteLine("0) Torna al menu principale");
                Console.Write("Scelta: ");

                int scelta = int.Parse(Console.ReadLine());

                switch (scelta)
                {
                    case 1: InserisciDocente(); break;
                    case 2: VisualizzaDocenti(); break;
                    case 3: ModificaDocente(); break;
                    case 4: EliminaDocente(); break;
                    case 0: running = false; break;
                    default: Console.WriteLine("Scelta non valida."); break;
                }
            }
        }

        private void InserisciDocente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            var docente = new Docente
            {
                Name = nome,
                Materia = materia
            };

            var controller = new DocenteController();
            controller.InserisciDocente(docente);

            Console.WriteLine("Docente inserito correttamente!");
        }

        private void VisualizzaDocenti()
        {
            var controller = new DocenteController();
            var docenti = controller.GetDocenti().ToList();

            Console.WriteLine("\nLista docenti ordinata:");
            foreach (var d in docenti)
            {
                Console.WriteLine($"ID: {d.Id}, Nome: {d.Name}, Materia: {d.Materia}");
            }
        }

        private void ModificaDocente()
        {
            VisualizzaDocenti();

            Console.Write("Inserisci ID da modificare: ");
            int id = int.Parse(Console.ReadLine());

            var controller = new DocenteController();
            var docente = controller.GetDocenteById(id);

            if (docente == null)
            {
                Console.WriteLine("Docente non trovato!");
                return;
            }

            Console.Write("Nuovo Nome: ");
            docente.Name = Console.ReadLine();

            Console.Write("Nuova Materia: ");
            docente.Materia = Console.ReadLine();

            controller.ModificaDocente(docente);
            Console.WriteLine("Docente modificato correttamente!");
        }

        private void EliminaDocente()
        {
            VisualizzaDocenti();

            Console.Write("Inserisci ID da eliminare: ");
            int id = int.Parse(Console.ReadLine());

            var controller = new DocenteController();
            controller.EliminaDocente(id);

            Console.WriteLine("Docente eliminato correttamente!");
        }
    }
}
