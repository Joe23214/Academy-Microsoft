using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    public class GestioneIo
    {

        public int menu()
        {
            int scelta = 0;
            Console.WriteLine("Benvenuto nella gestione libri!");
            Console.WriteLine("1) Inserire un libro");
            Console.WriteLine("2) visualizzare tutti i libri");
            Console.WriteLine("3) Ricercare un libro per titolo");
            Console.WriteLine("4) Modificare un libro");
            Console.WriteLine("5) ricerca Libri Per Autore");
            Console.WriteLine("6) Conta i libri");
            Console.WriteLine("7) ricerca un libro per id");
            Console.WriteLine("8) Eliminare un libro per id");
            Console.WriteLine("9) Eliminare tutti i libri presenti (puliusci la mensola)");
            Console.WriteLine("10) ordina i libri per prezzo");
            Console.WriteLine("0) Uscire dal programma");
            scelta = Convert.ToInt32(Console.ReadLine());
            if (scelta != 0 && scelta >= 0 && scelta <= 10)
            {
                Console.WriteLine($"si è scelto il numero {scelta}");
                return scelta;
            }
            else
            {
                Console.WriteLine($"scelta {scelta} non corretta, in chiusura...");
                return 0;
            }
            

        }

        
       
        public Libro inserisciLibro()
        {
            Console.WriteLine("codice libro univoco generato automaticamente!");
            string codLibro = Program.GenerateId();
            Console.WriteLine("Inserisci l'isbn del libro:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del libro:");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci il genere del libro:");
            string genere = Console.ReadLine();
            Console.WriteLine("Inserisci il nome dell' autore libro:");
            string autore = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di pagine del libro:");
            int npag = Convert.ToInt32(Console.ReadLine());
            return new Libro(codLibro,isbn,titolo,autore,npag,genere);
        }

        public Libro EditLibro()
        {
            Console.WriteLine("Inserisci l'isbn del libro:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del libro:");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci il genere del libro:");
            string genere = Console.ReadLine();
            Console.WriteLine("Inserisci il nome dell' autore libro:");
            string autore = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di pagine del libro:");
            int npag = Convert.ToInt32(Console.ReadLine());
            Libro x = new Libro();
            x.setIsbn(isbn);
            x.setNumeroPagine(npag);
            x.setGenere(genere);
            x.setAutore(autore);
            x.setTitolo(titolo);
            return x;         

        }

        public string ricercaTitolo()
        {
            Console.WriteLine("Inserisci il titolo del libro che vuoi cercare");
            string titolo = Console.ReadLine();
            return titolo;
        }

        public string ricercaAutore()
        {
            Console.WriteLine("Inserisci l'autore dei libri che vuoi cercare");
            string autore = Console.ReadLine();
            return autore;
        }

        public string ricercaId()
        {
            Console.WriteLine("Inserisci l'id del libro che vuoi cercare");
            string id = Console.ReadLine();
            return id;
        }

        public string eliminaId()
        {
            Console.WriteLine("Inserisci l'id del libro che vuoi eliminare");
            string id = Console.ReadLine();
            return id;
        }

        public void pulisciMensola()
        {
            Console.WriteLine("sto pulendo la mensola, butto tutti i libri.");
        }

        public void ordinalibri()
        {
            Console.WriteLine("sto ordinando tutti i libri per prezzo");
        }

    }
}
