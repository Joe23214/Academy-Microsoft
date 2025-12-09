using System;

namespace EfDemo.View
{
    public class MenuView
    {
        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU PRINCIPALE ===");
                Console.WriteLine("1) Gestione Studenti");
                Console.WriteLine("2) Gestione Docenti");
                Console.WriteLine("0) Esci");
                Console.Write("Scelta: ");

                int scelta = int.Parse(Console.ReadLine());

                switch (scelta)
                {
                    case 1:
                        new StudenteView().ShowMenuStudente();
                        break;

                    case 2:
                        new DocenteView().ShowMenuDocente();
                        break;

                    case 0:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
    }
}
