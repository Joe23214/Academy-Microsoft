using System;
using System.Text.RegularExpressions;

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
        public int eta;
        public string telefono;
        public string email;
        }

        Anagrafica s;

        s.Nome = Mario;
        s.eta = 28;
        Console.writeLine($"Nome: {s.nome}");



        struct [] Anagrafica;

        INIZIA DA CRUD
        AGGIUNGI RICERCA PER CAMPO E RANGE DI ETA'
        CONTROLLI E UNIVOCITA' ( mail, numero di telefono, regex su mail,eta positiva,ignorecase)
        */
        static int LeggiIntero(string messaggio)
        {
            int valore;
            do
            {
                Console.WriteLine(messaggio);
                if (int.TryParse(Console.ReadLine(), out valore))
                    return valore;

                Console.WriteLine("Valore non valido, riprovare.");
            } while (true);
        }

        static void OrdinaAnagrafica()
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = 0; j < s.Length - 1 - i; j++)
                {
                    if (!string.IsNullOrEmpty(s[j].codID) &&
                        !string.IsNullOrEmpty(s[j + 1].codID))
                    {
                        int id1 = int.Parse(s[j].codID);
                        int id2 = int.Parse(s[j + 1].codID);

                        if (id1 > id2)
                        {
                            Anagrafica temp = s[j];
                            s[j] = s[j + 1];
                            s[j + 1] = temp;
                        }
                    }
                }
            }
        }


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
                    int id = LeggiIntero(s[i].codID);
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

            int eta;
            while (true)
            {
                eta = LeggiIntero("inserisci l'età dell'utente");
                if (eta >= 0 && eta <= 100) break;
                Console.WriteLine("età non valida, reinserire.");
            }

            string telefono;
            while (true)
            {
                Console.WriteLine("inserisci il telefono dell'utente");
                telefono = Console.ReadLine();

                if (telefono.Length < 10)
                {
                    Console.WriteLine("numero troppo corto.");
                    continue;
                }

                bool duplicato = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].telefono == telefono)
                    {
                        duplicato = true;
                        break;
                    }
                }

                if (!duplicato) break;

                Console.WriteLine("numero di telefono già presente, reinserire.");
            }

            string email;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            while (true)
            {
                Console.WriteLine("inserisci l'email dell'utente");
                email = Console.ReadLine();

                if (Regex.IsMatch(email, pattern)) break;

                Console.WriteLine("mail non valida, reinserire.");
            }

            Anagrafica a = new Anagrafica
            {
                codID = codID,
                Nome = nome,
                Cognome = cognome,
                eta = eta,
                telefono = telefono,
                email = email
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (string.IsNullOrEmpty(s[i].codID))
                {
                    s[i] = a;
                    break;
                }
            }

            Console.WriteLine("############Utente inserito con successo!############\n");
            OrdinaAnagrafica();
        }

        static void visualizzaUtenti()
        {
            Console.WriteLine("############visualizza utenti############");
            Console.WriteLine("utenti in anaghrafica:");
            bool trovato = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!string.IsNullOrEmpty(s[i].codID))
                {
                    trovato = true;
                    Console.WriteLine($"CodID: {s[i].codID}");
                    Console.WriteLine($"Nome: {s[i].Nome}");
                    Console.WriteLine($"Cognome: {s[i].Cognome}");
                    Console.WriteLine($"Età: {s[i].eta}");
                    Console.WriteLine($"Telefono: {s[i].telefono}");
                    Console.WriteLine($"Email: {s[i].email}");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            if (!trovato)
                Console.WriteLine("Nessun utente presente.");
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
                    OrdinaAnagrafica();
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

                    while (true)
                    {
                        s[i].eta = LeggiIntero("inserisci la nuova età dell'utente");
                        if (s[i].eta >= 0 && s[i].eta <= 100) break;
                        Console.WriteLine("Età non valida.");
                    }

                    while (true)
                    {
                        Console.WriteLine("inserisci il nuovo telefono dell'utente");
                        s[i].telefono = Console.ReadLine();

                        if (s[i].telefono.Length >= 10) break;

                        Console.WriteLine("Telefono non valido.");
                    }

                    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                    while (true)
                    {
                        Console.WriteLine("inserisci la nuova email dell'utente");
                        s[i].email = Console.ReadLine();

                        if (Regex.IsMatch(s[i].email, pattern)) break;

                        Console.WriteLine("Email non valida.");
                    }

                    Console.WriteLine("############Utente modificato con successo!############\n");
                    OrdinaAnagrafica();
                    return;
                }
            }

            Console.WriteLine("Utente non trovato.");
        }

        static void ricercaUtente()
        {
            int scelta;

            do
            {
                Console.WriteLine("############ricerca utente############");
                Console.WriteLine("per cosa si vuole cercare l'utente?");
                Console.WriteLine("1. CodID");
                Console.WriteLine("2. Nome");
                Console.WriteLine("3. Cognome");
                Console.WriteLine("4. Range Età");
                Console.WriteLine("5. Telefono");
                Console.WriteLine("6. Email");
                Console.WriteLine("0. Esci");
                scelta = LeggiIntero("Scelta: ");

                bool trovato;

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("inserisci il codice id dell'utente da cercare:");
                        string codID = Console.ReadLine();
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].codID == codID)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome} - {s[i].email}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 2:
                        Console.WriteLine(
                             "inserisci il nome dell'utente da cercare:");
                        string nome = Console.ReadLine();
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].Nome?.Equals(nome, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome} - {s[i].email}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 3:
                        Console.WriteLine(
                            "inserisci il cognome dell'utente da cercare:");
                        string cognome = Console.ReadLine();
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].Cognome?.Equals(cognome, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome} - {s[i].email}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 4:
                        int min = LeggiIntero("inserisci l'età minima:");
                        int max = LeggiIntero("inserisci l'età massima:");
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].eta >= min && s[i].eta <= max && s[i].codID != null)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome} - {s[i].email}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 5:
                        Console.WriteLine("inserisci il telefono dell'utente da cercare:");
                        string tel = Console.ReadLine();
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].telefono == tel)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 6:
                        Console.WriteLine("inserisci l'email dell'utente da cercare:");
                        string email = Console.ReadLine();
                        trovato = false;

                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i].email == email)
                            {
                                trovato = true;
                                Console.WriteLine($"{s[i].Nome} {s[i].Cognome}");
                            }
                        }

                        if (!trovato) Console.WriteLine("nessun utente trovato.");
                        break;

                    case 0:
                        return;
                }

            } while (scelta != 0);
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
                Console.WriteLine("5. Ricerca");
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
                        visualizzaUtenti(); //UI
                        eliminazioneUtente();
                        break;
                    case 4:
                        modificaUtente();
                        break;
                    case 5:
                        ricercaUtente();
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