using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   
    public class MainView
    {
       
        public void stampaStringa(string s){
            Console.WriteLine( s);
     }
        public string LeggiStringa(string msg){
            Console.Write(msg + " ");
            string str = Console.ReadLine();
            return str;
        }
        public int LeggiIntero(string msg)
        {
            Console.Write(msg + " ");
            int numInt = 0;
            bool flag = true;
            while (flag)
            {
                try
                {
                    int prova = Convert.ToInt32(Console.ReadLine());
                    numInt = prova;
                    flag = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Il numero inserito non è valido. Riprova");
                }
            }
            return numInt;


        }
        public double LeggiDouble(string msg)
        {
            Console.Write(msg + " ");
            double numDoub = 0;
            bool flag = true;
            while (flag)
            {
                try
                {
                    double prova = Convert.ToDouble(Console.ReadLine());
                    numDoub = prova;
                    flag = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Il numero inserito non è valido. Riprova");
                }
            }
            return numDoub;


        }

        public void visualizzaMenù() {
                bool running = true;

                while (running)
                {
                int scelta = LeggiIntero("inserisci la scelta:");

                    switch (scelta)
                    {
                        case 1:
                            
                            break;

                        case 2:
                            break;

                        case 3:
                            break;

                        case 4:
                            break;

                        case 5:
                            break;

                        case 0:
                            running = false;
                            break;

                        default:
                            LeggiStringa("Scelta non valida..");
                            scelta = LeggiIntero("inserisci la scelta:");
                             break;
                    }

                    Console.WriteLine("\nPremi un tasto per continuare...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }   
    

public void CreateProdotto() {
            Pcrud crudProdotti = new Pcrud();
            string nome = LeggiStringa("Inserisci il nome del prodotto:");
            double prezzo = LeggiDouble("Inserisci il prezzo del prodotto:");
            int giacenza = LeggiIntero("Inserisci la giacenza del prodotto:");
            //istanzio oggetto
            Prodotti p  = new Prodotti(nome,prezzo,giacenza);
            //passo al crud
            crudProdotti.createProdotto(p);
            //fine
            LeggiStringa("Inserimento completato!");
        }
    }
}