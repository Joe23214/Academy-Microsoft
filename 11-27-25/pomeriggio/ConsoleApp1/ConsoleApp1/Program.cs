using System;
using ConsoleApp1.Views;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            InterfacciaRepository repo = new Repository();
            var controller = new UniversitàController(repo);

            var view = new MenuView(controller);
            view.Start();
        }
    }
}
