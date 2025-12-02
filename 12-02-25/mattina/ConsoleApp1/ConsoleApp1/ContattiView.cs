using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class ContattiView
    {

        public void DisplayMenu()
        {
            Console.WriteLine("===== MENU CONTATTI =====");
            Console.WriteLine("1) Visualizza contatti");
            Console.WriteLine("2) Aggiungi nuovo contatto");
            Console.WriteLine("3) Modifica un contatto");
            Console.WriteLine("4) Cancella un contatto");
            Console.WriteLine("5) Visualizza titoli di studio");
            Console.WriteLine("0) Esci");
            Console.WriteLine("=========================");
        }

        public int getChoice()
        {
            return leggiIntero("Scegli un'opzione:");
        }

        public Contatto NuovoContatto(Contatto c)
        {
            Console.WriteLine("=== Modifica contatto ===");

            c.nome = LeggiStringa($"Nome ({c.nome})");
            c.cognome = LeggiStringa($"Cognome ({c.cognome})");
            c.indirizzo = LeggiStringa($"Indirizzo ({c.indirizzo})");
            c.citta = LeggiStringa($"Citta ({c.citta})");
            c.TdS = leggiIntero($"Titolo di studio ID ({c.TdS})");

            return c;
        }

        public void Visualizza(List<TitoloStudio> l)
        {
            Console.WriteLine("=== Titoli di studio disponibili ===");

            foreach (var t in l)
            {
                Console.WriteLine($"ID: {t.Id}  TITOLO: {t.Titolo}");
            }
        }

        public Contatto GetNewContattoData()
        {
            Console.WriteLine("=== Inserisci nuovo contatto ===");

            Contatto c = new Contatto();

            c.nome = LeggiStringa("Inserisci nome:");
            c.cognome = LeggiStringa("Inserisci cognome:");
            c.indirizzo = LeggiStringa("Inserisci indirizzo:");
            c.citta = LeggiStringa("Inserisci città:");
            c.TdS = leggiIntero("Inserisci ID titolo di studio:");

            return c;
        }

        public int getContattoId()
        {
            return leggiIntero("Inserisci ID del contatto:");
        }


        public void DisplayContatti(List<Contatto> c)
        {
            foreach (var contatto in c)
            {
                Console.WriteLine($"ID: {contatto.id}  NOME: {contatto.nome}  COGNOME: {contatto.cognome}  INDIRIZZO: {contatto.indirizzo}  CITTA: {contatto.citta}  TDS: {contatto.TdS}");
            }
        }

        public void DisplaySuccess(string msg)
        {
            Console.WriteLine(msg);
        }

        public void DisplayError(string msg)
        {
            Console.WriteLine("Errore: " + msg);
        }

        public string LeggiStringa(string msg)
        {
            Console.Write(msg + "   ");
            string str = Console.ReadLine();
            return str;
        }

        public int leggiIntero(string msg)
        {
            Console.Write(msg + "   ");
            int numInt = 0;
            bool flag = true;

            while (flag)
            {
                try
                {
                    numInt = int.Parse(Console.ReadLine() ?? "");
                    flag = false;
                }
                catch (Exception)
                {
                    Console.Write("Valore non valido. Riprova: ");
                }
            }

            return numInt;
        }
    }
}
