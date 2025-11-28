using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Studente
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string Matricola { get; }
        public CorsoDiLaurea CorsoIscritto { get; set; }

        public Studente(string nome, string cognome, string matricola)
        {
            Nome = nome;
            Cognome = cognome;
            Matricola = matricola;
        }

        public override string ToString()
        {
            string corso = CorsoIscritto != null ? CorsoIscritto.Nome : "Non iscritto";
            return $"{Nome} {Cognome} (Mat: {Matricola}) - Corso: {corso}";
        }
    }

}
