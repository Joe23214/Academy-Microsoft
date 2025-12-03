using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class ContattiView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1) Visualizza contatti");
            Console.WriteLine("2) Aggiungi contatto");
            Console.WriteLine("3) Modifica contatto");
            Console.WriteLine("4) Elimina contatto");
            Console.WriteLine("5) Visualizza titoli di studio");
            Console.WriteLine("6) Aggiungi titolo di studio");
            Console.WriteLine("7) Modifica titolo di studio");
            Console.WriteLine("8) Elimina titolo di studio");
            Console.WriteLine("0) Esci");
            Console.WriteLine("=================");
        }

        public int GetChoice() => LeggiIntero("Scegli un'opzione:");

        public Contatto NuovoContatto(Contatto c)
        {
            Console.WriteLine("=== Modifica contatto ===");
            c.nome = LeggiStringa($"Nome ({c.nome})");
            c.cognome = LeggiStringa($"Cognome ({c.cognome})");
            c.indirizzo = LeggiStringa($"Indirizzo ({c.indirizzo})");
            c.citta = LeggiStringa($"Città ({c.citta})");
            c.TdS = LeggiIntero($"Titolo di studio ID ({c.TdS})");
            return c;
        }

        public Contatto GetNewContattoData()
        {
            Console.WriteLine("=== Nuovo contatto ===");
            Contatto c = new Contatto();
            c.nome = LeggiStringa("Nome:");
            c.cognome = LeggiStringa("Cognome:");
            c.indirizzo = LeggiStringa("Indirizzo:");
            c.citta = LeggiStringa("Città:");
            c.TdS = LeggiIntero("Titolo di studio ID:");
            return c;
        }

        public TitoloStudio GetNewTitolo()
        {
            Console.WriteLine("=== Nuovo titolo di studio ===");
            TitoloStudio t = new TitoloStudio();
            t.Titolo = LeggiStringa("Titolo:");
            return t;
        }

        public void DisplayContatti(List<Contatto> c)
        {
            Console.WriteLine("=== Contatti ===");
            foreach (var contatto in c)
                Console.WriteLine($"ID: {contatto.id}  Nome: {contatto.nome}  Cognome: {contatto.cognome}  Indirizzo: {contatto.indirizzo}  Città: {contatto.citta}  TDS: {contatto.TdS}");
        }

        public void DisplayTitoliStudio(List<TitoloStudio> l)
        {
            Console.WriteLine("=== Titoli di studio ===");
            foreach (var t in l)
                Console.WriteLine($"ID: {t.Id}  Titolo: {t.Titolo}");
        }

        public void DisplaySuccess(string msg) => Console.WriteLine(msg);
        public void DisplayError(string msg) => Console.WriteLine("Errore: " + msg);

        public string LeggiStringa(string msg)
        {
            Console.Write(msg + " ");
            return Console.ReadLine() ?? "";
        }

        public int LeggiIntero(string msg)
        {
            int num;
            while (true)
            {
                Console.Write(msg + " ");
                if (int.TryParse(Console.ReadLine(), out num))
                    return num;
                Console.WriteLine("Valore non valido. Riprova.");
            }
        }
    }
}
