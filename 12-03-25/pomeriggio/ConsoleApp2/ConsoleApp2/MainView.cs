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
            Console.WriteLine("Benvenuto nel menù");
            Console.WriteLine("scegli una delle seguenti opzioni:");
            Console.WriteLine("1) Inserisci un prodotto");
            Console.WriteLine("2) Visualizza tutti i prodotti");
            Console.WriteLine("3) Seleziona prodotto per Id");
            Console.WriteLine("4) Modifica un prodotto");
            Console.WriteLine("5) Elimina un prodotto");
            Console.WriteLine("6) Inserisci una Categoria");
            Console.WriteLine("7) Visualizza tutte le Categorie");
            Console.WriteLine("8) Seleziona Categoria per Id");
            Console.WriteLine("9) Modifica una Categoria");
            Console.WriteLine("10) Elimina una Categoria");

        }   
    

        public Prodotto CreateProdotto(Prodotto p) {
             p.nome = LeggiStringa("Inserisci il nome del prodotto:");
             p.prezzo = LeggiDouble("Inserisci il prezzo del prodotto:");
             p.giacenza = LeggiIntero("Inserisci la giacenza del prodotto:");            
            return p;
        }
        public void ViewAll(List<Prodotto> l) { 
        if(l.Count() == 0)
            {
                Console.WriteLine("Non ci sono Prodotti in DB!");
            }
            else
            {
                foreach (var x in l)
                {
                    Console.WriteLine(x.ToString());
                }
            }
        
        }
        public Prodotto selezionaId(Pcrud p) {
            Console.Write("Inserisci l'id del prodotto da seleizonare:");
            int id = int.Parse(Console.ReadLine());
            Prodotto pr = new Prodotto();
            List<Prodotto> list = p.viewAll();
            foreach (var x in list)
            {
                if (x.id == id)
                {
                    Console.Write($"PRODOTTO TROVATO:\n \n" +
                        $"ID: {x.id} \n" +
                        $"NOME: {x.nome} \n" +
                        $"PREZZO: {x.prezzo}  \n" +
                        $"GIACENZA: {x.giacenza} \n ");
                   
                    pr = x;
                }
                
            }
            return pr;
        }

        public Prodotto modificaProdotto(Prodotto pr) {

            Console.WriteLine("Inserisci il nuovo nome del prodotto o premi invio per non modificarlo");
            string nuovonome = Console.ReadLine();
            if ("".Equals(nuovonome))
            {
                Console.WriteLine("Non hai modificato il nome");
            }
            else {
                pr.nome = nuovonome;
                Console.WriteLine($"nuovo nome inserito: {nuovonome}");
            }
                Console.WriteLine("Inserisci il nuovo prezzo del prodotto o premi invio per non modificarlo");
            string nuovoprezzo = Console.ReadLine();
            if ("".Equals(nuovoprezzo))
            {
                Console.WriteLine("Non hai modificato il prezzo");
            }
            else
            {
                pr.prezzo = Double.Parse(nuovoprezzo);
                Console.WriteLine($"nuovo prezzo inserito: {nuovoprezzo}");
            }
            Console.WriteLine("Inserisci la nuova giacenza del prodotto  o premi invio per non modificarla");
            string nuovaGiacenza = Console.ReadLine();
            if ("".Equals(nuovaGiacenza))
            {
                Console.WriteLine("Non hai modificato la giacenza");
            }
            else
            {
                pr.giacenza = int.Parse(nuovaGiacenza);
                Console.WriteLine($"nuova giacenza inserita: {nuovaGiacenza}");
            }
            return pr;
        }

        //categorie
        public Categoria CreateCategoria(Categoria c)
        {
            c.TipoCategoria = LeggiStringa("Inserisci il nome della categoria:");
            return c;
        }

    }
}