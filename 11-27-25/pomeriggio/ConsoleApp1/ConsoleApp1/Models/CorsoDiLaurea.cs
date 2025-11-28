using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class CorsoDiLaurea
    {
        private string Codice { get; }
        private string Nome { get; }
        private List<Professore> Professori { get; }
        private List<string> Materie { get; }

        public CorsoDiLaurea(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
            Professori = new List<Professore>();
            Materie = new List<string>();
        }

        public override string ToString()
        {
            string profs = string.Join(", ", Professori.Select(p => p.Nome + " " + p.Cognome + $" ({p.Materia})"));
            return $"{Nome} (Cod: {Codice}) - Professori: {profs}";
        }
    }

}
