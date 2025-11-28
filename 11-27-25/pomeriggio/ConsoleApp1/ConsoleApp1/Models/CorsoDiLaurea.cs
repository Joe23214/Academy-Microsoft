using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class CorsoDiLaurea
    {
        public string Codice { get; }
        public string Nome { get; }
        public List<Professore> Professori { get; }
        public List<string> Materie { get; }

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
