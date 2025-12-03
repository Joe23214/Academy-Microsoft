using System;

namespace ConsoleApp1
{
    public class Voto
    {
        public string Materia { get; set; }
        public int Valore { get; set; }
        public DateTime Data { get; set; }

        public Voto(string materia, int valore)
        {
            Materia = materia;
            Valore = valore;
            Data = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Valore} ({Data:dd/MM/yyyy})";
        }
    }
}
