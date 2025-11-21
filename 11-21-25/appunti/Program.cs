namespace ConsoleApplicationsArgs
{
    class ConsoleArgs
    {

        /*21-11-05*/
        /*
        static void Main(string[] args)
        {

            //args[0] -> nome
            //args[1] -> cognome

            Console.Write("Ciao {0} {1}\n", args[0], args[1]);

            //oppure

            Console.Write($"Ciao {args[0]} {args[1]}\n");

            Console.Write("\n");
            Console.Write("Premi un tasto per terminare il programma");
            Console.ReadKey();

             */
        /*
        si possono valorizzare gli argomenti nel main andando in proprietà di progetto, Debug, e inserendo gli argomenti nella casella "Argomenti della riga di comando" e così verranno valorizzati senza dicvhiararli nel codice
        */
        /*
        static void Main(string[] args)
        {
            int[] numeri; // dichiarazione array semplice (no inizializzaizone)
            string[] nomi;
            double[] valori;
            //in questo caso creiamo solo il riferimento in memoria, quindi non esiste (non valorizzato)
            int[] numeri1  = new int[5]; // dichiarazione e inizializzazione array di 5 elementi (valorizzati a 0)
            int[] ints = new int[] { 1, 2, 3, 4, 5 }; // dichiarazione, inizializzazione e valorizzazione array di 5 elementi - esplicita
            int[] numeri3 = { 1, 2, 3 }; // formato breve dichiarazione, inizializzazione e valorizzazione array di 3 elementi - implicita
            // inizializzazione in due passaggi
            int[] numeri4;
            //... codic ein execution
            numeri4 = new int[] { 10, 20, 30, 40 };
            var numeri5 = new[] { 100, 200, 300, 400 }; // dichiarazione, inizializzazione e valorizzazione array di 4 elementi - implicita con var
            object[] dati = { 1, "pippo", 3.14, 'a', true }; // array di oggetti (diversi tipi di dato)}
            /*
            ricerca di un elemento di un vettore (posizione)
            r. lineare oppure r. binaria (dicotomica)
            fusione di due array ordinati
            ordinare array (complessita n^2 a n(log n))
            gli algoritmi di sorting vengono scelti  in base all'input:

             */
        //ricerca di un elemento di un vettore, può essere lineare o binaria (dicotomica)
        /*
        int[] valoriRicerca = { 10, 20, 30, 40 };
        int valoreDaCercare = 30;
        for (int i = 0; i < valoriRicerca.Length; i++)
        {
            if (valoriRicerca[i] == valoreDaCercare)
            {
                Console.WriteLine($"Valore {valoreDaCercare} trovato alla posizione {i}");
                break; // esce dal ciclo for
            }   


        }

        /* 10 -10:30 non c'ero*/


        //  }
        /*

        //passare per valore
        static void Main(string[] args)
        {

            int x = 7;
            int retn;

            retn = passaValByValore(x); // passaggio per valore
            Console.WriteLine($"Valore di x dopo il passaggio per valore: {x}"); // x rimane 7 poiche punta alla stessa locazione di memoria
        }

        static int passaValByValore(int a)  
        {
            a ++;
            return a;
        }
        */

        //passare per riferimento
        /*
        static void Main(string[] args)
        {
            int x = 7;
            int retn;
            retn = passaValByRef(ref x);
            Console.WriteLine($"Valore di x dopo il passaggio per riferimento: {x}"); // x diventa 8 poiche punta alla locazione di memoria di x
        }

        //ref serve per puntare alla stessa locazione di memoria
        static int passaValByRef(ref int a)
        {
            a++;
            return a;
        }
        */
        /*
         Anagrafica: raccolta di record in vari formati, ad esempio tabelle oppure a scheda.
         attributi:codId, nome,cognome,eta,telefono,email

         i vetytori avranno la stessa dimensione
         tenere ordinata l'anagrafica
         codId univoco (criterio di progressione)
         inserimento scheda per dati
         */
        static void Main(string[] args)
        {

        string[] codId;
        string[] nome;
        string[] cognome;
        int[] eta;
        string[] telefono;
        string[] email;

        //
        Console.Write("\n");
        Console.Write("premi un tasto per terminare...");
        Console.ReadKey();
        }

        public struct Anagrafica
        {
            public string codId;
            public string nome;
            public string cognome;
            public int eta;
            public string telefono;
            public string email;
        }
        Anagrafica s = new Anagrafica();
        s.nome = "Mario";
        s.eta = 30;
        s.telefono = "1234567890";
        s.email = "mail@mail.com";
        struct []Anagrafica;
    }
}