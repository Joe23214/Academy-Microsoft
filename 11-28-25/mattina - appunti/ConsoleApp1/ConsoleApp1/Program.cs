using System;
using System.Collections;
using System.Runtime.InteropServices;
using static MyApp.Program;

namespace MyApp //relativo a progetto -> introGenerics
{
    public class Program
    {
        static void Main(string[] args)
        {
            //cenni codifica funzionale
            //delegate
            //eventi
            stampaStringa("ciao, sopno un metodo statico nella classe program \n");

            Utility.Stampami();
            EsempiUsoClassi();
           


        }

        public static void StampaStringa(string str) => Console.WriteLine(str);

        public static void stampaStringa(string s)
        {
            Console.WriteLine(s);
        }



        public class Persona
        {
            public string nome;

            //metodo -> freccia -> singola espressione

            public virtual void Saluta() => Console.WriteLine($"ciao sono{nome}");

            public void salutaOldStyle() => Console.WriteLine($"giorno, mi chiamo {nome}");
        }

        //interfaccia
        //interfaccia è anche un tipo, nello specifico un tipo di dati astratto

        public interface IStudente
        {
            void Studia();
        }


        public interface IAnimale
        {
            void Verso();
        }

        public class Cane : IAnimale
        {
            public void Verso()
            {
                Console.WriteLine("roar");
            }
        }

        public class Studente : Persona, IStudente  //come implementa interfaccia in c#
        {
            public string CorsoDiStudi { get; set; }
            public void Studia() => Console.WriteLine($"{nome} sta studiando {CorsoDiStudi}");   //deve implementarlo per forza poichè è legato ad interfaccia


            public override void Saluta() => Console.WriteLine(base.Saluta + $" sono a scuola");

            /*
           public override void Saluta()
            {
                base.Saluta();
                Console.WriteLine("sono a scuola");
            }             
            */


        }
        public class ArrayExample
        {
            public void EsempioArray()
            {
                int[] numeri = new int[5];
                numeri[0] = 10;
                numeri[1] = 20;
                numeri[2] = 30;
                numeri[3] = 40;
                numeri[4] = 50;
                foreach (int n in numeri)
                {
                    Console.WriteLine(n);
                }
            }
        }

        public class ArraylistExample
        {
            public void EsempioArrayList()
            {
                ArrayList lista = new ArrayList();
                lista.Add(1);
                lista.Add(2);
                lista.Add(3);
                lista.Add(4);
                lista.Add(5);

                foreach (int n in lista)
                {
                    Console.WriteLine(n);
                }

            }

           
        }

        public class Massimodi2Valori
        {

            public static int Massimo(int a, int b) => (a > b) ? a : b;
            public static double MassimoD(double a, double b) => (a > b) ? a : b;

           // public static string MaxString(string a, string b) => (Convert.ToInt32(a) > Convert.ToInt32(b)) ? a : b; (?)
            public static string MaxString(string a, string b) => a.CompareTo(b) <= 0 ? b : a;
            /*
            public static string MaxString(string a, string b) { 
             if(a.CompareTo(b) <= 0)
                {
                    return b;

                }
                else
                {
                    return a;
                }
            }
            */
            public static T MaxGeneric<T>(T a, T b) where T: IComparable<T>
            {
                return a.CompareTo(b) <= 0 ? b : a;
            }
        }

        public static void EsempiUsoClassi()
        {
            StampaStringa("Esempio uso classi:");
            StampaStringa("da class Persona:");
            Persona p = new Persona();
            p.nome = "mario";
            p.Saluta();
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
            StampaStringa("da class studente: ");
            Studente s = new Studente();
            s.nome = "luigi";
            s.CorsoDiStudi = "informatica";
            s.Saluta();
            s.Studia();
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
                               ////////////////////////////////
            StampaStringa("da esempio array\n");
            ArrayExample ae = new ArrayExample();
            StampaStringa("Esempio Array:\n");
            ae.EsempioArray();
            Console.Write("Premi un tasto per continuare\n");
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
                               ////////////////////////////////
            StampaStringa("da esempio ArrayList:\n");
            ArraylistExample ale = new ArraylistExample();
            ale.EsempioArrayList();
            StampaStringa("Premi un tasto per continuare");
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
            StampaStringa("da esempio Interfaccia(cioè un Tipo) Animale\n");
            IAnimale a = new Cane();
            a.Verso();
                             ////////////////////////////////
            StampaStringa("massimo tra due valori con meotdi NON generici:");
            Console.WriteLine(Massimodi2Valori.Massimo(5,0));
            Console.WriteLine(Massimodi2Valori.MassimoD(5.2, 11.1));
            "ciao".CompareTo("ciaopiùlungo"); //ritorna int32
            Console.WriteLine(Massimodi2Valori.MaxString("B", "A"));
            Console.WriteLine(Massimodi2Valori.MaxString("ciao", "ciaopiùlungo"));
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
                               ////////////////////////
            StampaStringa("massimo tra due valori con meotdi generici:");
            Console.WriteLine(Massimodi2Valori.MaxGeneric(5, 0));
            Console.WriteLine(Massimodi2Valori.MaxGeneric(5.2, 11.1));
            Console.WriteLine(Massimodi2Valori.MaxGeneric("carlo", "aldo"));
            //test:
            Console.WriteLine(Massimodi2Valori.MaxGeneric("mario", "Mario"));
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli
                               ////////////////////////
            UsaScatole us = new UsaScatole();
            us.esempi();
            Console.ReadKey(); // non deve essere presente nella separazione dei ruoli

        }



        public class UsaScatole //contorller come program
        {
            
            public void esempi()
            {
                Console.WriteLine("sono in esempi Scatole!");
                scatola0<string> scatolaStringa = new scatola0<string>();
                scatolaStringa.Contenuto = "Ciao mondo";
                Console.WriteLine(scatolaStringa.Contenuto);

                scatola0<int> sI = new scatola0<int>();
                sI.Contenuto = 22;
                Console.WriteLine(sI.Contenuto);
                Scatola1<double> sD = new Scatola1<double>();
                sD.Set( 22.5);
                Console.WriteLine(sD.Get());
                Scatola1<Persona> scatolaPersona = new Scatola1<Persona>();
                Persona p = new Persona { nome = "Anna" };
                Console.WriteLine(scatolaPersona.Get());
                // Esempio metodo Swap
                Scatola1<int> box = new Scatola1<int>();

                int a = 5;
                int b = 9;
                Console.WriteLine(a); //5
                Console.WriteLine(b); //9

                box.Swap(ref a, ref b);

                Console.WriteLine(a); // 9
                Console.WriteLine(b); // 5
            }

        }
        //manteniamo tipi generici così da poter metterci più tipi
        public class scatola0<T>
        {
            public T? Contenuto { get; set; }
        }

        class Scatola1<T>
        {
            private T? contenuto { get; set; }
            public T? Get()
            {
                return contenuto;
            }
            public void Set(T obj)
            {
                contenuto = obj;
            }
            public void Swap(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }


        }
        public class Utility
        {
            public static void Stampami()
            {
                //metodo come variabile
                void Stampami(string s) => Console.WriteLine(s);

                var f = Stampami;
                f("test classe utility");
            }
           
        }

    }
}
/*
 Esempi di Collezioni Generice in C#

-//Liste: List<T>:
List <int> persone = new List<int>();
ecc.

List <Persona> persone = new List<Persona>();
List <Dipendente> dipendenti = new List<Dipendente>();
List <string> nomi = new List<string>();
nomi.Add("Marco");
nomi.Add("Luca");
nomi.Add("Anna");

foreach(string s in nomi){
s.toString();
}

-//Dictionary<TKey, TValue>

Dictionary<int, string> studenti = new Dictionary<int, string>();
studenti.Add(101,"Marco");
studenti.Add(102,"Luca");
studenti.Add(103,"Anna");

 Console.WriteLine(studenti[102]); // Luca

//controllo
if (studenti.ContainsKey(103)){
Console.WriteLine(studenti[103]);
}

//iterazione
foreach(var c in studenti){
Console.WriteLine($"Matricola:{c.Key} Nome: {c.value} ");

-//Queue<T>
// -- FIFO --la coda risponde ad un algoritmo First in First Out, si contrappone allo Stack
Queue<string> msg = new Queue<string>();

//inserimento
msg.Enqueue ("Messaggio1");
msg.Enqueue ("Messaggio2");
msg.Enqueue ("Messaggio3");

//prelevare dalla coda, ovviamente verranno emessi in oridne di inserimento ogni volta che viene chiamata
msg.Dequeue (); //"Messaggio1"
msg.Dequeue (); //"Messaggio2"
msg.Dequeue (); //"Messaggio3"

//per prendere un elemento senza eliminarlo dalla coda si usa Peek, sarà sempre il primo elemento in ordine di arrivo in coda
msg.Peek(); //"Messaggio1" -> verrà solo visualizzato
msg.Dequeue (); //"Messaggio1" -> lo andro ad eliminare poichè è il primo ad essere entrato ed è ancora presente


-//Stack<T> -- LIFO -- Last In First Out (Pila di piatti)

Stack<int> pila = new Stack<int>();

pila.push(10);
pila.push(20);
pila.push(10);
pila.push(30);


pila.Pop(); -> mi darà 30 perchè è stato l'ultimo ad essere stato inserito, e lo rimuioverà

pila.Peek(); -> mi darà 10 in seguito all'eliminazione del 30 tramite Pop, e non lo eliminerà
pila.Peek(); -> mi darà 10
pila.Peek(); -> mi darà 10
pila.Pop(); -> mi darà 10, eliminandola quindi

}
 */