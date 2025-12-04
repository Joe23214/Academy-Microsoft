using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Studente1 : IEntita
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Matricola { get; set; }

        public string Id => Matricola;

    

     public override string ToString()
        {
            return $"{Nome} {Cognome} (Mat: {Matricola})";
        }

    }

}