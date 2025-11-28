using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Professore
    {
        private string Nome { get; }
        private string Cognome { get; }
        private string Id { get; }
        private string Materia { get; }
        private List<CorsoDiLaurea> Corsi { get; }

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
