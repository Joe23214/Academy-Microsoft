using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Studente
    {
        private string Nome { get; }
        private string Cognome { get; }
        private string Matricola { get; }
        private CorsoDiLaurea CorsoIscritto { get; set; }

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
