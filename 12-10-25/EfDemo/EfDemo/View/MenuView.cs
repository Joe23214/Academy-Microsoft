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
                Console.WriteLine("3) Gestione Corsi");
                Console.WriteLine("0) Esci");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        new StudenteView().ShowMenu();
                        break;

                    case "2":
                        new DocenteView().ShowMenu();
                        break;

                    case "3":
                        new CorsoView().ShowMenu();
                        break;

                    case "0":
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
