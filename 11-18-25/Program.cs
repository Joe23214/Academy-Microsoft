/*.net 6:
 See https://aka.ms/new-console-template for more information
using System;
.net 5 darebbe:
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();   // <-- tiene aperta la console
        }
    }
}
______________________________________________________________________________________________
 .csproj è il file xml di configurazione dle progetto C# in Visual Studio/*
/* 
 Scrivere un programma che, richiesti in input 3 numeri interi, visualizzi a seconda dei casi una delle seguenti risposte:
Tutti uguali
Due uguali e uno diverso (indicando i numeri uguali)
Tutti diversi
 */
using System;
namespace MyApp
{
    /* internal class Program
     {
         static void Main(string[] args)
         {
             Console.WriteLine("Hello World!");
             int a, b, c;
             Console.Write("a=");
             a = int.Parse(Console.ReadLine());
             Console.Write("b=");
             b = int.Parse(Console.ReadLine());
             Console.Write("c=");
             c = int.Parse(Console.ReadLine());

             if (a == b && b == c)
             {
                 Console.WriteLine("Tutti uguali");
             }
             else if (a == b || a == c || b == c)
             {
                 if (a == b)
                 {
                     Console.WriteLine($"Due uguali: {a} e uno diverso: {c}");
                 }
                 else if (a == c)
                 {
                     Console.WriteLine($"Due uguali: {a} e uno diverso: {b}");
                 }
                 else // b==c
                 {
                     Console.WriteLine($"Due uguali: {b} e uno diverso: {a}");
                 }
             }
             else
             {
                 Console.WriteLine("Tutti diversi");
             }
             Console.Write("Press any key for continue ...");
             Console.ReadKey();


         }
     }
    */


    /*
     *Scrivere un pro0gramma che implementi una semplice calcolatrice. Il programma deve chiedere all'utente di inserire due numeri e l'operazione da eseguire (+,-,*,/)
     */
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
          
            double num1, num2, result = 0;
            char operazione;
            Console.Write("Inserisci il primo numero: ");
            num1 = double.Parse(Console.ReadLine());
            if(num1 == null )
            {
                Console.WriteLine("Errore: inserire un numero valido.");
                Console.Write("Press any key for continue ...");
                Console.ReadKey();
                return; // esce dal programma
            }
            Console.Write("Inserisci il secondo numero: ");
            num2 = double.Parse(Console.ReadLine());
            if (num2 == null)
            {
                Console.WriteLine("Errore: inserire un numero valido.");
                Console.Write("Press any key for continue ...");
                Console.ReadKey();
                return; // esce dal programma
            }
            Console.Write("Inserisci l'operazione desiderata tra (+,-,*,/) ");
            operazione = char.Parse(Console.ReadLine());

            // con if:

            /* if(operazione == '+')
             {
                 result = num1 + num2;
                 Console.Write("Il risultato è" + result);
             }
             else if(operazione == '-')
             {
                 result = num1 - num2;
                 Console.Write("Il risultato è" + result);
             }
             else if(operazione == '*')
             {
                 result = num1 * num2;
                 Console.Write("Il risultato è" + result);
             }
             else if(operazione == '/')
             {
                 if(num2 != 0)
                 {
                     result = num1 / num2;
                     Console.Write("Il risultato è" + result);
                 }
                 else
                 {
                     Console.WriteLine("Errore: divisione per zero non consentita.");
                     Console.Write("Press any key for continue ...");
                     Console.ReadKey();
                     return; // esce dal programma
                 }
             }
             else
             {
                 Console.WriteLine("Operazione non valida.");
                 Console.Write("Press any key for continue ...");
                 Console.ReadKey();
                 return; // esce dal programma
             }
            */

    // con switch:
    /*
    switch (operazione)
    {
        case '+':
            result = num1 + num2;
           // Console.WriteLine("Il risultato è " + result);
            break;
        case '-':
            result = num1 - num2;
           // Console.WriteLine("Il risultato è " + result);
            break;
        case '*':
            result = num1 * num2;
            //Console.WriteLine("Il risultato è " + result);
            break;
        case '/':
            result = num1 / num2;
            if (num2 != 0)
            {
                result = num1 / num2;
                Console.Write("Il risultato è" + result);
                break;
            }
            else
            {
                Console.WriteLine("Errore: divisione per zero non consentita.");
                Console.Write("Press any key for continue ...");
                Console.ReadKey();
                break;
            }
        default:
            //si mette il dollaro perchè senza non riuscirebbe a trasmettere il valore alla graffa (segnaposto). l'alternativa sarebbe la concatenazione di stringhe                    Console.WriteLine($"Operazione: {operazione} non corretta! è possibile inserire solo uno tra questi:(+,-,*,/) ");
            break;

    }
    */
    /*
     variante con unico log (si commentano i log nello switch):
    */
    /*
    Console.WriteLine("Il risultato è " + result);


    Console.Write("Press any key for continue ...");
    Console.ReadKey();


}
} */


    /*
    inserire n interi da tastiera da sommare
    */
    /*
    dare la somma di tutti i numeri pari compresi tra 5 e 30
    */
    /*
     alla fine del ciclo chiedere all'utente se vuyole continuare a ciclare e continuare a sommare nuovi numeri
     */
    internal class Program
         {
             static void Main(string[] args)
             {
            int cont = 0;
            while (cont == 0)
            {
                Console.WriteLine("Inserisci il numero di volte che vuoi sommare numeri");
                 int a;
                 Console.Write("numero cicli =");
                 a = int.Parse(Console.ReadLine());
                 int res = 0;
                 int s = 1;
                 int res2 = 0;
            while (a > 0)
                {

                    Console.WriteLine($"Inserisci il {s}° numero intero da sommare");
                    int num;
                    Console.Write("numero =");
                    num = int.Parse(Console.ReadLine());
              if(num % 2 == 0 && num >= 5 && num <= 30)
                {
                    res2 += num;
                }
                    a--;
                    s++;
                    res += num;
                }
                Console.WriteLine($"La somma dei numeri inseriti è: {res}" );
                Console.WriteLine($"La somma dei numeri inseriti pari e compresi trra 5 e 30 è: {res2}");

                string scelta;
                Console.Write("Vuoi testare altri numeri? ( premi 1 per confermare, altrimenti un altro tasto.)");
                scelta = Console.ReadLine();
                if (scelta == "1") { 
                    cont = 0; 
                }
                else
                {
                    cont = 1;
                }
               // Console.ReadKey(); fa dare due volte invio o tasto


            }
         }
    }
}