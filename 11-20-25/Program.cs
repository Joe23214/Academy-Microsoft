using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            programma nel quale si chiedono due numeri e questi due numeri si sommano mostrandola
            */
            /* Console.WriteLine("Inserisci due numeri da sommare.");
             Console.WriteLine("Inserisci il primo numero:");
             int x = int.Parse(Console.ReadLine());
             bool successo = false;
             Console.WriteLine("Inserisci il secondo numero:");
             int y = int.Parse(Console.ReadLine());
             int z = x + y;
             if ( z != null && z != 0)
             {
                 successo = true;

             }
             else
             {
                 successo = false;
                 Console.WriteLine("C'è stato un errore nel calcolo della somma. verifica i numeri in input");
             }
             Console.WriteLine("La somma dei due numeri è: " + z);
             Console.ReadLine(); */

            /*fatto anche con while e do while e if per verificare il fatto che i numeri inseriti siano int :*/
            /* PS:  sono pigro non l'ho fatto */
            /* versione con switch + implementazioni: */
            int scelta;
            double x, y,ris;
            do
            {
                Console.WriteLine("menù");
                Console.WriteLine("1. somma");
                Console.WriteLine("2. divisione");
                Console.WriteLine("3. sottrazione");
                Console.WriteLine("4. moltiplicazione");
                Console.WriteLine("5. chiedi media");
                Console.WriteLine("6. inserimento dati in array");
                Console.WriteLine("7. continue su dowhile");
                Console.WriteLine("8. operatore ternario");
                Console.WriteLine("0. esci");
                scelta = int.Parse(Console.ReadLine());
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserisci il primo numero:");
                        x = CheckNumber(Console.ReadLine());
                        Console.WriteLine("Inserisci il secondo numero:");
                        y = CheckNumber(Console.ReadLine());
                        // int ris = x + y;
                        ris = somma(x, y);
                        Console.WriteLine($"il risultato è {ris}. ");
                        break;
                    case 2:

                        Console.WriteLine("Inserisci il primo numero:");
                        x = CheckNumber(Console.ReadLine());
                        Console.WriteLine("Inserisci il secondo numero:");
                        y = CheckNumber(Console.ReadLine());
                        // double ris2 = z / a;
                         ris = rapporto(x,y);
                        Console.WriteLine($"il risultato è {ris}. ");
                        break;
                    case 3:

                        Console.WriteLine("Inserisci il primo numero:");
                        x = CheckNumber(Console.ReadLine());
                        Console.WriteLine("Inserisci il secondo numero:");
                        y = CheckNumber(Console.ReadLine());
                        //double ris3 = b - c;
                        ris = sottrazione(x,y);
                        Console.WriteLine($"il risultato è {ris}. ");
                        break;
                    case 4:

                        Console.WriteLine("Inserisci il primo numero:");
                        x = CheckNumber(Console.ReadLine());
                        Console.WriteLine("Inserisci il secondo numero:");
                        y = CheckNumber(Console.ReadLine());
                        // double ris4 = d * e;
                        ris = moltiplicazione(x,y);
                        Console.WriteLine($"il risultato è {ris}. ");
                        break;
                    case 5:
                        chiediMedia();
                        break;
                    case 6:

                        /*
                    Arrray
                    */

                        int[] numeri = new int[5];
                        Console.WriteLine($"{numeri[2]}");

                        int[] numeriPari = { 2, 4, 6, 8, 10 };
                        int i = 0;
                        for (i = 0; i < numeriPari.Length; i++)
                        {
                            Console.WriteLine($"il numero in posizione {i} è {numeriPari[i]}");
                        }

                        //programma: chiedi entro 20 numeri quanti numeri vuole inserire (n di prima amssimo 20)
                        //metti i valori in un array
                        //fai la media
                        Console.WriteLine("Quanti numeri vuoi inserire? (Massimo 20)");
                        double n = CheckNumber(Console.ReadLine());
                        if (n > 20 && n > 0)
                        {
                            Console.WriteLine("troppi numeri da inserire o valore negativo, il massimo è 20.");
                            return;
                        }
                        double[] arr = new double[20];
                        int j = 0;
                        while (j < n)
                        {
                            Console.WriteLine($"inserisci il {j + 1}° numero.");
                            double nx = CheckNumber(Console.ReadLine());

                            arr[j] = nx;
                            j++;
                        }
                        Console.WriteLine("Ecco l'array:");
                        for (int s = 0; s < arr.Length; s++)
                        {
                            Console.WriteLine($"{arr[s]}");
                        }
                        Console.WriteLine($"Ecco la media: {mediaArr(arr)} ");
                        break;
                    case 7:
                        /*
                        dowhile che chiede di inserire un numero positivo all'utente ed esca quando è negativo
                        */
                        Boolean a = true;
                        while (a)
                        {
                            Console.WriteLine("inserisci un numero");
                            int s = int.Parse(Console.ReadLine());


                            if (s < 0)
                            {
                                Console.WriteLine($"hai inserito {s} non va bene");
                                return;
                            }
                            
                        }
                        break;
                    case 8:
                        Console.WriteLine("inserisci un numero");
                        double numero = CheckNumber(Console.ReadLine());
                        string isPari = numero % 2 == 0 ? "il numero è pari" : "il numero non è pari";
                        Console.WriteLine(isPari);
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
        static double somma(double a, double b)
        {
            return a + b;
        }
        static double sottrazione(double a, double b)
        {
            return a - b;   
        }
        static double rapporto(double a, double b)
        {
            return a / b;
        }
        static double moltiplicazione(double a, double b)
        {
            return a * b;
        }

        static double CheckNumber(string input)
        {
            double numero;

            while ( !double.TryParse(input, out numero)){
                Console.WriteLine("input nojn valido");
                input = Console.ReadLine();
            }
            return numero;
        }

        /*
         funzione media e richiesta numeri in input
         */

        static double media(double n, double somma)
        {
            return somma / n;
        }
        static void chiediMedia()
        {
            double n, somma = 0, i = 1;
            Console.WriteLine("di quanti numeri vuoi fare la media?");
            n = CheckNumber(Console.ReadLine());
            for (int j = 0; j <= n; j++)
            {
                Console.WriteLine($"inserisci il {i}° numero");
                double a = CheckNumber(Console.ReadLine());
                somma += a;
                i++;
            }
            Console.WriteLine("la somma è " + somma);
            Console.WriteLine("la media è " + media(n,somma));
        }

        static double mediaArr(double []array)
        {
            double somma = 0;
            for (int i = 0; i < array.Length; i++)
            {
                somma += array[i];
            }
            return media(array.Length,somma);
        }
       
    }
}
