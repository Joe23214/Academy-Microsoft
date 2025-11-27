using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class CorsoDiLaurea
    {
        public string Codice { get; }
        public string Nome { get; }
        public List<Professore> Professori { get; }

        public HashSet<string> Materie => new HashSet<string>(Professori.Select(p => p.Materia));

        public CorsoDiLaurea(string codice, string nome)
        {
            Codice = codice;
            Nome = nome;
            Professori = new List<Professore>();
        }

        public void AggiungiProfessore(Professore prof)
        {
            if (!Professori.Contains(prof))
            {
                Professori.Add(prof);
                prof.AggiungiCorso(this);
            }
        }

        public void AggiungiMateria(string materia)
        {
            Materie.Add(materia);
        }

        public override string ToString()
        {
            string profs = string.Join(", ", Professori.Select(p => p.Nome + " " + p.Cognome + $" ({p.Materia})"));
            return $"{Nome} (Cod: {Codice}) - Professori: {profs}";
        }
    }
}
