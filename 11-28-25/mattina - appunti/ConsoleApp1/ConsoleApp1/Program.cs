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