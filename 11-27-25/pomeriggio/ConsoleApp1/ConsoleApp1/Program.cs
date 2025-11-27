using System;
using ConsoleApp1.Views;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();
            var controller = new UniversitàController(repo);

            var view = new MenuView(controller);
            view.Start();
        }
    }
}
