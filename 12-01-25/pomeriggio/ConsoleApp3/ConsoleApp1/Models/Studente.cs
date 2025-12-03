using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Studente : IComparable<Studente>
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string Matricola { get; }
        public CorsoDiLaurea? CorsoIscritto { get; set; }
        public double MediaCalcolata { get; set; }

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

        public int CompareTo(Studente? other)
        {
            if (other == null) return 1;
            int confrontoMedia = other.MediaCalcolata.CompareTo(this.MediaCalcolata);
            if (confrontoMedia != 0) return confrontoMedia;
            int confrontoCognome = this.Cognome.CompareTo(other.Cognome);
            if (confrontoCognome != 0) return confrontoCognome;
            return this.Nome.CompareTo(other.Nome);
        }
    }
}
