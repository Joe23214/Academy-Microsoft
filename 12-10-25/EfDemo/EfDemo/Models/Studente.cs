using System;
using System.Collections.Generic;
using System.Text;

namespace EfDemo.Models
{
    /*
     Una classe POCO (Plain Old CLass) è una classe che rappresenta un semplice
oggetto di dominio. La sua semplicità la rende facilmente utilizzabile per
serializzazione, deserializzazione e per passare dati tra diversi strati di
un'applicazione.
     */
    public class Studente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public string Matricola { get; set; }
        public List<Corso> Corsi  { get; set; } = new();

    }

}