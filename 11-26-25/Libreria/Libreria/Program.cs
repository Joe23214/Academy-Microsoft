using System;

namespace Libreria
{
   
    class Program
    {

        public static void ricercaLibroPerAutore(Mensola mensola) {
            GestioneIo gi = new GestioneIo();
            string autore = gi.ricercaAutore();
            List<Libro> mensol = mensola.getLibri();
            int count = 0;
            foreach (Libro m in mensol)
            {
                if (m.getAutore().Equals(autore))
                {
                    Console.WriteLine(m.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Non ci sono libri dell'autore: {autore}");
            }
        }

        public static void ricercaLibroPerTitolo(Mensola mensola)
        {
            GestioneIo gi = new GestioneIo();
            string titolo = gi.ricercaTitolo();
            List<Libro> mensol = mensola.getLibri();
            int count = 0;
            foreach (Libro m in mensol)
            {
                if (m.getTitolo().Equals(titolo))
                {
                    Console.WriteLine(m.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Non ci sono libri con il titolo: {titolo}");
            }

        }

        public static int countLibri(Mensola mensola)
        {
            List<Libro> mensol = mensola.getLibri();
            int count = mensola.getLibri().Count();
            Console.WriteLine($"In libreria abbiamo {count} libri");
            return count;

        }

        public static void inserisciInLibreria(Mensola mensola)
        {
            GestioneIo gi = new GestioneIo();
            Libro newLibro = gi.inserisciLibro();
            if (countLibri(mensola) > 50)
            {
                Console.WriteLine("La mensola è alla massima capienza, elimina dei libri per aggiungerne altri");
            }
            else
            {
                Console.WriteLine("libro inserito in mensola con successo!");
                Console.WriteLine($"libro: {newLibro.ToString()}");
                mensola.getLibri().Add(newLibro);
            }
                
           

        }

        public static void visualizzaTuttiILibri(Mensola mensola)
        {
            List<Libro> mensol = mensola.getLibri();
            foreach (Libro m in mensol)
            {
                Console.WriteLine(m.ToString());
            }
            }

        public static void editLibro(Mensola mensola)
        {
            GestioneIo gi = new GestioneIo();
            string codice = gi.ricercaId();
            List<Libro> libri = mensola.getLibri();
            int count = 0;
            foreach (Libro libro in libri)
                if (libro.getCodiceLibro() == codice)
                {
                    Libro x = gi.EditLibro();
                    libro.setIsbn(x.getIsbn());
                    libro.setNumeroPagine(x.getNumberoPagine());
                    libro.setTitolo(x.getTitolo());
                    libro.setAutore(x.getAutore());
                    libro.setGenere(x.getGenere());
                    count++;
                }
            if (count == 0)
            {
                Console.WriteLine($"non è stato trovato nessun libro per il codice {codice}");
            }
               
        }
        public static void ricercaLibroPerId(Mensola mensola)
        {
            GestioneIo gi = new GestioneIo();
            string id = gi.ricercaId();
            List<Libro> mensol = mensola.getLibri();
            int count = 0;
            foreach (Libro m in mensol)
            {
                if (m.getCodiceLibro().Equals(id))
                {
                    Console.WriteLine(m.ToString());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Non ci sono libri con codice: {id}");
            }
        }

        public static void eliminaLibroPerId(Mensola mensola)
        {
            GestioneIo gi = new GestioneIo();
            string id = gi.eliminaId();
            List<Libro> mensol = mensola.getLibri();
            int count = 0;
            foreach (Libro m in mensol)
            {
                if (m.getCodiceLibro().Equals(id))
                {
                    mensola.getLibri().Remove(m);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"Non ci sono libri con l'id: {id}");
            }

        }
        static void Main(string[] args)
        {

            Console.WriteLine("Benvenuto nella gestione libri!");
            GestioneIo gi = new GestioneIo();
            Mensola mensola = new Mensola();
                bool exit = false;
                while (!exit)
                {
                   
                    Console.Write("Scegli un'opzione: ");
                int choice = gi.menu();
                    switch (choice)
                    {
                        case 1:
                        inserisciInLibreria(mensola);
                        break;
                        case 2:
                        visualizzaTuttiILibri(mensola);
                        break;
                        case 3:
                        ricercaLibroPerTitolo(mensola);
                            break;
                        case 4:
                        visualizzaTuttiILibri(mensola);
                        editLibro(mensola);
                                break;
                        case 5:
                        ricercaLibroPerAutore(mensola);
                            break;
                        case 6:
                        countLibri(mensola);
                            break;
                        case 7:
                        ricercaLibroPerId(mensola);
                        break;
                        case 8:
                        eliminaLibroPerId(mensola);
                        break;
                        case 9:
                        gi.pulisciMensola();
                        mensola.pulisciMensola();
                        break;
                        case 10:
                        gi.ordinalibri();
                        mensola.ordinaPerPrezzo();
                        break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opzione non valida.");
                            break;
                    }




                }




            }

       
        public static string GenerateId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            char[] id = new char[5];

            for (int i = 0; i < 5; i++)
            {
                id[i] = chars[random.Next(chars.Length)];
            }

            return new string(id);
        }
    }
    }




   