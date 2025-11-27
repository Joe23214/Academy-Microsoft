using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Repository
    {
        public Dictionary<string, Studente> Studenti { get; set; }
        public Dictionary<string, Professore> Professori { get; set; }
        public Dictionary<string, CorsoDiLaurea> Corsi { get; set; }

        public Repository()
        {
            Studenti = new Dictionary<string, Studente>();
            Professori = new Dictionary<string, Professore>();
            Corsi = new Dictionary<string, CorsoDiLaurea>();
        }
    }
}
