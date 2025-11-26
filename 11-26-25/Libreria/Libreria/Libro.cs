using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class Libro
    {
        private string codiceLibro;
        private string isbn;
        private string titolo;
        private string autore;
        private int numeroPagine;
        private string genere;
        private const double costoPagina = 0.05;
        private const double costoFisso = 7.5;
        public double getCostoFisso() => costoFisso;
        public double getCostoPagina() => costoPagina;
        public string getCodiceLibro() => codiceLibro;
        public string getIsbn() => isbn;
        public string getTitolo() => titolo;
        public string getAutore() => autore;
        public string getGenere() => genere;

        public int getNumberoPagine() => numeroPagine;
        public void setIsbn(string isbn) => this.isbn = isbn;
        public void setTitolo(string titolo) => this.titolo = titolo;
        public void setAutore(string autore) => this.autore = autore;
        public void setNumeroPagine(int numeroPagine) => this.numeroPagine = numeroPagine;
        public void setGenere(string genere) => this.genere = genere;
        public Libro()
        {

        }
        public Libro(string codiceLibro, string isbn, string titolo, string autore, int numeroPagine, string genere)
        {
            this.codiceLibro = codiceLibro;
            this.isbn = isbn;
            this.titolo = titolo;
            this.autore = autore;
            this.numeroPagine = numeroPagine;
            this.genere = genere;
        }
        //override metodi equals-toString

        public override string ToString()
        {
            return $"Codice: {codiceLibro}\n" +
                   $"ISBN: {isbn}\n" +
                   $"Titolo: {titolo}\n" +
                   $"Autore: {autore}\n" +
                   $"Genere: {genere}\n" +
                   $"Pagine: {numeroPagine}\n" +
                   $"Prezzo: {Prezzo():0.00}€";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Libro other)
                return false;

            return this.isbn == other.isbn;
        }


        public double Prezzo()
        {
            return costoFisso + (costoPagina * numeroPagine);
        }

    }
}
