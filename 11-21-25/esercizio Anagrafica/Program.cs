using System;

namespace MyApp
{
    internal class Program
    {
        /*
        // anagrafica: raccolta di record in vari formati , ad esempio tabellare oppure a scheda.
        attributi: codID, Nome, Cognome, eta, telefono, email

        // i vettori avranno la stessa dimensione
        // tenere ordinata l'anagrafica
        // codID unoivoco (rispetti un criterio di progressione)
        // inserimento scheda per scheda

        string[]codID;
        string[]Nome;
        string[]Cognome;
        int[]eta;
        string[]telefono;
        string[]email;

        //
        public struct Angrafica
        {
        public string codID;
        public string Nome;
        public string Cognome;
        public int[]eta;
        public string[]telefono;
        public string[]email;


        }

        Anagrafica s;

        s.Nome = Mario;
        s.eta = 28;
        Console.writeLine($"Nome: {s.nome}");



        struct [] Anagrafica;

        INIZIA DA CRUD

        */

        public struct Anagrafica
        {
            public string codID;
            public string Nome;
            public string Cognome;
            public int eta;
            public string telefono;
            public string email;
        }
        static Anagrafica[] s = new Anagrafica[100];

        static string generazioneCodIDProgressivo()
        {
            int maxID = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].codID != null)
                {
                    int id = int.Parse(s[i].codID);
                    if (id > maxID)
                    {
                        maxID = id;
                    }
                }
            }
            return (maxID + 1).ToString("D4");
        }
       

        static void inserimentoUtente()
        {
            Console.WriteLine("############inserimento utente############");
            Console.WriteLine("il codeice id viene generato automaticamente..");
            string codID = generazioneCodIDProgressivo();
            Console.WriteLine("inserisci il nome dell'utente");
            string nome = Console.ReadLine();
            Console.WriteLine("inserisci il cognome dell'utente");
            string cognome = Console.ReadLine();
            Console.WriteLine("inserisci l'età dell'utente");
            int eta = int.Parse(Console.ReadLine());
            Console.WriteLine("inserisci il telefono dell'utente");
            string telefono = Console.ReadLine();
            Console.WriteLine("inserisci l'email dell'utente");
            string email = Console.ReadLine();
            Anagrafica a = new Anagrafica();
            a.codID = codID;
            a.Nome = nome;
            a.Cognome = cognome;
            a.eta = eta;
            a.telefono = telefono;
            a.email = email;
            Console.WriteLine("############Utente inserito con successo!############\n");
            Console.WriteLine($"CodID: {a.codID}");
            Console.WriteLine($"Nome: {a.Nome}");
            Console.WriteLine($"Cognome: {a.Cognome}");
            Console.WriteLine($"Età: {a.eta}");
            Console.WriteLine($"Telefono: {a.telefono}");
            Console.WriteLine($"Email: {a.email}");
            Console.WriteLine("#########################################\n");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].codID == null)
                {
                    s[i] = a;
                    break;
                }
            }
        }
        static void visualizzaUtenti()
        {
            Console.WriteLine("############visualizza utenti############");
            Console.WriteLine("utenti in anaghrafica:");
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].codID != null)
                {
                    Console.WriteLine($"CodID: {s[i].codID}");
                    Console.WriteLine($"Nome: {s[i].Nome}");
                    Console.WriteLine($"Cognome: {s[i].Cognome}");
                    Console.WriteLine($"Età: {s[i].eta}");
                    Console.WriteLine($"Telefono: {s[i].telefono}");
                    Console.WriteLine($"Email: {s[i].email}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            Console.WriteLine(
                "#########################################\n");
            





        }
        static void eliminazioneUtente()
        {
            Console.WriteLine("############eliminazione utente############");
            Console.WriteLine("inserisci il codice id dell'utente da eliminare:");
            string codID = Console.ReadLine();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].codID == codID)
                {
                    s[i] = new Anagrafica();
                    Console.WriteLine("############Utente eliminato con successo!############\n");
                    return;
                }
            }
            Console.WriteLine("Utente non trovato.");
        }
        static void modificaUtente()
        {
            Console.WriteLine("############modifica utente############");
            Console.WriteLine("inserisci il codice id dell'utente da modificare:");
            string codID = Console.ReadLine();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].codID == codID)
                {
                    Console.WriteLine("inserisci il nuovo nome dell'utente");
                    s[i].Nome = Console.ReadLine();
                    Console.WriteLine("inserisci il nuovo cognome dell'utente");
                    s[i].Cognome = Console.ReadLine();
                    Console.WriteLine("inserisci la nuova età dell'utente");
                    s[i].eta = int.Parse(Console.ReadLine());
                    Console.WriteLine("inserisci il nuovo telefono dell'utente");
                    s[i].telefono = Console.ReadLine();
                    Console.WriteLine("inserisci la nuova email dell'utente");
                    s[i].email = Console.ReadLine();
                    Console.WriteLine("############Utente modificato con successo!############\n");
                    return;
                }
            }
            Console.WriteLine("Utente non trovato.");
        }
        static void Main(string[] args)
        {

            int scelta;
            do
            {
                Console.WriteLine("menù");
                Console.WriteLine("1. Inserimento");
                Console.WriteLine("2. lista");
                Console.WriteLine("3. eliminazione");
                Console.WriteLine("4. modifica");
                Console.WriteLine("0. esci");
                scelta = int.Parse(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        inserimentoUtente();
                        break;
                    case 2:
                        visualizzaUtenti();
                        break;
                    case 3:
                        eliminazioneUtente();
                        break;
                    case 4:
                        modificaUtente();
                        break;
                    case 0:
                        Console.WriteLine("In chiusura...");
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
            } while (scelta != 0);

        }
    }
}