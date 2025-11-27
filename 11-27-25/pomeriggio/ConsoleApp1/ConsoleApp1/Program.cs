using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentiController controller = new StudentiController();
            MenuView view = new MenuView(controller);

            view.Start();
        }
    }
}