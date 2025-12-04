using System;
using ConsoleApp1.Views;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logService = new LogService();
            InterfacciaRepository repo = new Repository();
            var controller = new UniversitàController(repo, logService);

            var view = new MenuView(controller, logService);
            view.Start();
        }
    }
}
