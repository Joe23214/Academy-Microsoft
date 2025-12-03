using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Prodotti
    {
        public int id { get; set; }
        public string nome { get; set; }
        public double prezzo { get; set; }
        public double giacenza { get; set; }

        public Prodotti( string nome, double prezzo, double giacenza)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.giacenza = giacenza;
        }
    }
}
