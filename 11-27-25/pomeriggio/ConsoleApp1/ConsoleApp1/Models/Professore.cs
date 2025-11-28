using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Professore
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string Id { get; }
        public string Materia { get; }
        public List<CorsoDiLaurea> Corsi { get; }

        public Professore(string nome, string cognome, string id, string materia)
        {
            Nome = nome;
            Cognome = cognome;
            Id = id;
            Materia = materia;
            Corsi = new List<CorsoDiLaurea>();
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} (ID: {Id}) - Materia: {Materia}";
        }
    }

}
