using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Prodotto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public double prezzo { get; set; }
        public double giacenza { get; set; }
        public Prodotto() { }
        public Prodotto( string nome, double prezzo, double giacenza)
        {
            this.nome = nome;
            this.prezzo = prezzo;
            this.giacenza = giacenza;
        }

        public override string ToString()
        {
            return $"PRODOTTO: ID: {id}, NOME: {nome}, PREZZO: {prezzo}, GIACENZA:{giacenza}";
        }
    }
}
