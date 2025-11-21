using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int CheckNumber(string input)
            {
                int numero;

                while (!int.TryParse(input, out numero))
                {
                    Console.WriteLine("input nojn valido");
                    input = Console.ReadLine();
                }
                return numero;
            }
            static int mediaArr(int[] array)
            {
                int somma = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    somma += array[i];
                }
                return media(array.Length, somma);
            }
            static int media(int n, int somma)
            {
                return somma / n;
            }
            static int sommaArr(int[] array)
            {
                int somma = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    somma += array[i];
                }
                return somma;
            }
            static int minArr(int[] array)
            {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }
                return min;
            }
            static int maxArr(int[] array)
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
                return max;
            }
            static void es1()
            {
                /*
                        Es. 1
                       leggere un numero n da tastiera
                       dichiarare un vettore di n interi
                       chiedere all’utente di inserire valori
                       stampare i valori caricati nel vettore
                        */
                Console.WriteLine("Quanti numeri vuoi inserire?");
                string ns = Console.ReadLine();
                int n = CheckNumber(ns);
                if (n < 0)
                {
                    Console.WriteLine("il numeor non può essere negativo");
                    return;
                }
                int[] arr = new int[n];
                int j = 0;
                while (j < n)
                {
                    Console.WriteLine($"inserisci il {j + 1}° numero.");
                    int nx = CheckNumber(Console.ReadLine());

                    arr[j] = nx;
                    j++;
                }
                Console.WriteLine("Ecco l'array:");
                for (int s = 0; s < arr.Length; s++)
                {
                    Console.WriteLine($"{arr[s]}");
                }
            }
            static void es2()
            {
                /*Es. 2
                legga un numero n da tastiera, dichiari un vettore di n interi, riempia il vettore. Ottenga il vettore inverso, stampi il vettore ricavato.
                */
                Console.WriteLine("Quanti numeri vuoi inserire?");
                string ns = Console.ReadLine();
                int n = CheckNumber(ns);
                if (n < 0)
                {
                    Console.WriteLine("il numeor non può essere negativo");
                    return;
                }
                int[] arr = new int[n];
                int j = 0;
                while (j < n)
                {
                    Console.WriteLine($"inserisci il {j + 1}° numero.");
                    int nx = CheckNumber(Console.ReadLine());

                    arr[j] = nx;
                    j++;
                }
                Console.WriteLine("ricavo l'array inverso...");
                int[] arrInv = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arrInv[i] = arr[n - 1 - i];
                }
                Console.WriteLine("Ecco l'array inverso:");
                for (int s = 0; s < arr.Length; s++)
                {
                    Console.WriteLine($"{arrInv[s]}");
                }
            }
            static void es3()
            {
                /*Es. 3
                carica vettore di interi da tastiera e verifichi se: strettamente crescenti, strettamente decrescenti, Né strettamente crescenti né strettamente decrescenti
                */
                Console.WriteLine("Quanti numeri vuoi inserire?");
                string ns = Console.ReadLine();
                int n = CheckNumber(ns);

                if (n < 0)
                {
                    Console.WriteLine("il numero non può essere negativo");
                    return;
                }

                int[] arr = new int[n];

                int j = 0;
                while (j < n)
                {
                    Console.WriteLine($"Inserisci il {j + 1}° numero:");
                    arr[j] = CheckNumber(Console.ReadLine());
                    j++;
                }

                bool crescente = true;
                bool decrescente = true;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] >= arr[i + 1])  // non strettamente crescente
                        crescente = false;

                    if (arr[i] <= arr[i + 1])  // non strettamente decrescente
                        decrescente = false;
                }

                if (crescente)
                    Console.WriteLine("Il vettore è strettamente crescente.");
                else if (decrescente)
                    Console.WriteLine("Il vettore è strettamente decrescente.");
                else
                    Console.WriteLine("Il vettore NON è né strettamente crescente né strettamente decrescente.");
            }
            static void es4()
            {
                /*
                creare un vettore di 100 interi contenente numeri casuali compresi tra 1-100 e calcoli alcuni dati statistici:
                1) somma
                2) media
                3) min
                4) max
                */

                int size = 100; 
                int[] arr = new int[size];
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(1, 101);
                }
                int somma = sommaArr(arr);
                int media = mediaArr(arr);
                int min = minArr(arr);
                int max = maxArr(arr);
                Console.WriteLine($"Somma: {somma}");
                Console.WriteLine($"Media: {media}");
                Console.WriteLine($"Min: {min}");
                Console.WriteLine($"Max: {max}");




            }
            static void es5()
            {
                /*
                 creare un vettore di 100 interi contenente numeri casuali compresi tra 1-100 e un algoritmo per contare gli elementi pari compresi tra 10 e 20
                 */

                int size = 100;
                int[] arr = new int[size];
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    arr[i] = rand.Next(1, 101);
                }
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (arr[i] >= 10 && arr[i] <= 20 && arr[i] % 2 == 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Ci sono {count} numeri pari compresi tra 10 e 20.");
            }
            static void es6()
            {
                /*
                 legga da tastiera un numero intero, lo converta nel corrispondente numero ASCII (UNICODE).
                 */

                Console.WriteLine("Inserisci un numero intero:");
                int numero = CheckNumber(Console.ReadLine());

                // Controllo range char (0-65535) numeri piccoli sembrano non mostrare carattere, ma è corretto, x test usa 65,A
                if (numero < Char.MinValue || numero > Char.MaxValue)
                {
                    Console.WriteLine("Il numero non è convertibile in un carattere Unicode.");
                    return;
                }
                char carattere = (char)numero;
                Console.WriteLine($"Il carattere corrispondente al numero {numero} è '{carattere}'.");

            }
            int scelta;
            do
            {
                Console.WriteLine("menù");
                Console.WriteLine("1. Es.1");
                Console.WriteLine("2. Es.2");
                Console.WriteLine("3. Es.3");
                Console.WriteLine("4. Es.4");
                Console.WriteLine("5. Es.5");
                Console.WriteLine("6. Es.6"); 
                Console.WriteLine("0. esci");
                scelta = int.Parse(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        es1();
                        break;
                    case 2:
                        es2();
                        break;
                    case 3:
                        es3();                      
                        break;
                    case 4:
                        es4();                       
                        break;
                    case 5:
                        es5();
                        break;
                    case 6:
                        es6();
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
