/*
using System;
using System.Collections;

namespace MyApp
{
    internal class Program
    {


        public class Persona
        {
            private string nome;
            private string cognome;
            private int eta;
            public Persona(string nome, int eta,string cognome )
            {
                this.nome=nome;
                this.cognome = cognome;
                this.eta = eta;
            }
            //get e set
            public void setNome(string nome)
            {
                this.nome = nome;
            }
            public string getNome()
            {
                return nome;
            }
            public void setEta(int eta)
            {
                this.eta = eta;
            }
            public int getEta()
            {
                return eta;
            }
            public void setCognome(string cognome)
            {
                this.cognome = cognome;
            }
            public string getCognome()
            {
                return cognome;
            }

            public override string ToString()
            {
                return "Nome: " + nome + ", Cognome: " + cognome + ", Età: " + eta;
            }   

            public void mangia()
            {
                Console.WriteLine(nome + " sta mangiando.");
            }
            public void dormi()
            {
                Console.WriteLine(nome + " sta dormendo.");
            }
            public virtual void saluta()
            {
                Console.WriteLine("Ciao, mi chiamo " + nome + " " + cognome + " e ho " + eta + " anni.");
            }

            //getter e sette c# moderno 
            public string Nome { get => nome; set => nome = value; }
            public int Eta { get => eta; set => eta = value; }
            public string Cognome { get => cognome; set => cognome = value; }
        }
     public class Studente : Persona
        {
            private string matricola;
            private int dataIscrizione;
            public Studente(string nome, int eta, string cognome ,string matricola, int dataIscrizione) : base(nome, eta,cognome)
            {
                this.matricola = matricola;
                this.dataIscrizione = dataIscrizione;
            }
            public string Matricola { get => matricola; set => matricola = value; }
            public int DataIscrizione { get => dataIscrizione; set => dataIscrizione = value; }

            public override void saluta()
            {
                Console.WriteLine("Ciao, mi chiamo " + Nome + " " + Cognome + ", la mia matricola è " + matricola + " e mi sono iscritto nel " + dataIscrizione + ".");
            }
        }

     public class Insegnante : Persona
        {
            private string materia;
            private int stipendio { get; set; }
            public Insegnante(string nome, int eta, string cognome ,string materia, int stipendio) : base(nome, eta,cognome)
            {
                this.materia = materia;
                this.stipendio = stipendio;
            }
           
            public override void saluta()
            {
                int stipendioAnnuo = stipendio * 12;
                Console.WriteLine("Ciao, mi chiamo " + Nome + " " + Cognome + ", insegno " + materia + " e il mio stipendio annuo è di " + stipendioAnnuo + " euro.");
            }
        static void Main(string[] args)
        {




                /*
           Persona p = new Persona("Mario", 30,"Rossi");
           Studente s = new Studente("Luigi", 20,"Bianchi","12345",2022);
            s.dormi(); //metodo ereditato
            p.mangia();
            Console.WriteLine(p.ToString());
            Console.WriteLine(s.ToString());


            //ArrayList
            //creazione di un arrayList
            ArrayList arrayList = new ArrayList();

            //aggiunta di elementi
            arrayList.Add("Ciao");
            arrayList.Add(42);
            arrayList.Add(3.14);
            arrayList.Add(true);
            arrayList.Add(p); // aggiunta di un oggetto Persona
            arrayList.Add(s); // aggiunta di un oggetto Studente
            //stampa degli elementi
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //rimozione di un elemento
            arrayList.Remove(42);
            //stampa degli elementi dopo la rimozione
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //accesso a un elemento tramite indice
            Console.WriteLine("Elemento all'indice 1: " + arrayList[1]);
            Console.WriteLine();
            //modifica di un elemento
            arrayList[1] = "Modificato";
            //stampa degli elementi dopo la modifica
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //dimensione dell'arrayList
            Console.WriteLine("Dimensione dell'ArrayList: " + arrayList.Count);
            arrayList.Sort(); // ordina gli elementi funziona solo se gli elementi sono confrontabili tra loro
            arrayList.Reverse(); // inverte l'ordine degli elementi
            int numero = arrayList.Count; // restituisce il numero di elementi presenti nell'ArrayList
            arrayList.Clear(); // rimuove tutti gli elementi dall'ArrayList
               


                //creiamo un areraylist di varie persone 

                Persona p1 = new Persona("Mario", 30, "Rossi");
                Studente s1 = new Studente("Luigi", 20, "Bianchi", "12345", 2022);
                Insegnante i1 = new Insegnante("Anna", 40, "Verdi", "Matematica", 2000);
                ArrayList persone = new ArrayList();
                persone.Add(p1);
                persone.Add(s1);
                persone.Add(i1);
                //iteriamo l'arraylist e chiamiamo il metodo saluta per ogni persona
                //notare che il metodo saluta viene eseguito in base al tipo reale dell'oggetto
                foreach (Persona p in persone)
                {
                    p.saluta();
                }


                Console.WriteLine();
            Console.WriteLine(
                "Premi un tasto per uscire...");
            Console.ReadKey();



        }
    }
}
}
*/
/*
using System;
using System.Collections;

namespace MyApp
{
    internal class Program
    {
        //es.1 crea una classe progenitrice veicolo da cui derivano due classi principali veicolo terrestre e acquatico, nel veicolo acquatico
        //saranno presenti barca e nave, nel veicolo terrestre avremo camion, moto e auto.
        //le proprietà comuni saranno marca, modello, anno di produzione e targa. il metodo comune sarà calcola costo assicurazione.
        //proprietà tipiche di veicolo terrestre saranno numero di ruote, cilindrata.
        //proprietà tipiche di veicolo acquatico saranno lunghezza e tipo motore.
        //ogni classe specifica avrà il suo override di calcolo costo di assicurazione.
        public class Veicolo
        {
            private string Marca { get; set; }
            private string Modello { get; set; }
            private int AnnoProduzione { get; set; }
            private string Targa { get; set; }
            public virtual double CalcolaCostoAssicurazione()
            {
                return 0.0;
            }
            public Veicolo(string marca, string modello, int annoProduzione, string targa)
            {
                Marca = marca;
                Modello = modello;
                AnnoProduzione = annoProduzione;
                Targa = targa;
            }
            public override string ToString()
            {
                return $"Marca: {Marca}, Modello: {Modello}, Anno di Produzione: {AnnoProduzione}, Targa: {Targa}";
            }


        }
        public class VeicoloTerrestre : Veicolo
        {
            private int NumeroRuote { get; set; }
            private int Cilindrata { get; set; }
            public VeicoloTerrestre(string marca, string modello, int annoProduzione, string targa, int numeroRuote, int cilindrata)
                : base(marca, modello, annoProduzione, targa)
            {
                NumeroRuote = numeroRuote;
                Cilindrata = cilindrata;
            }
            public override double CalcolaCostoAssicurazione()
            {
                return 200.0 + (Cilindrata / 100.0);
            }
            public override string ToString()
            {
                return base.ToString() + $", Numero di Ruote: {NumeroRuote}, Cilindrata: {Cilindrata}";
            }
        }
        public class VeicoloAcquatico : Veicolo
        {
            private double Lunghezza { get; set; }
            private string TipoMotore { get; set; }
            public VeicoloAcquatico(string marca, string modello, int annoProduzione, string targa, double lunghezza, string tipoMotore)
                : base(marca, modello, annoProduzione, targa)
            {
                Lunghezza = lunghezza;
                TipoMotore = tipoMotore;
            }
            public override double CalcolaCostoAssicurazione()
            {
                return 300.0 + (Lunghezza * 10.0);
            }
            public override string ToString()
            {
                return base.ToString() + $", Lunghezza: {Lunghezza}, Tipo di Motore: {TipoMotore}";
            }
        }

        static void Main(string[] args)
        {
            Veicolo veicoloSample = new Veicolo("Fiat", "Panda", 2020, "AB123CD");
            VeicoloTerrestre auto = new VeicoloTerrestre("Toyota", "Corolla", 2019, "EF456GH", 4, 1600);
            VeicoloAcquatico barca = new VeicoloAcquatico("Yamaha", "WaveRunner", 2021, "IJ789KL", 3.5, "Fuoribordo");
            Console.WriteLine(veicoloSample.ToString());
            Console.WriteLine($"Costo Assicurazione Veicolo: {veicoloSample.CalcolaCostoAssicurazione()} euro");
            Console.WriteLine(auto.ToString());
            Console.WriteLine($"Costo Assicurazione Auto: {auto.CalcolaCostoAssicurazione()} euro");
            Console.WriteLine(barca.ToString());
            Console.WriteLine($"Costo Assicurazione Barca: {barca.CalcolaCostoAssicurazione()} euro");
            Console.WriteLine(Console.ReadLine());
            //veicoli terresti differenti es:
            VeicoloTerrestre trattore = new VeicoloTerrestre("Volvo", "FH16", 2018, "MN012OP", 18, 16000);
            Console.WriteLine(trattore.ToString());
            Console.WriteLine($"Costo Assicurazione Trattore: {trattore.CalcolaCostoAssicurazione()} euro");
           VeicoloAcquatico nave = new VeicoloAcquatico("Carnival", "Vista", 2015, "QR345ST", 290.0, "Diesel");
            Console.WriteLine(nave.ToString());
            Console.WriteLine($"Costo Assicurazione Nave: {nave.CalcolaCostoAssicurazione()} euro");
            //ArrayList di veicoli
            ArrayList veicoli = new ArrayList();
            veicoli.Add(auto);
            veicoli.Add(barca);
            veicoli.Add(trattore);
            veicoli.Add(nave);
            Console.WriteLine("\nElenco Veicoli e Costi Assicurazione:");
            foreach (Veicolo v in veicoli)
            {
                Console.WriteLine(v.ToString());
                Console.WriteLine($"Costo Assicurazione: {v.CalcolaCostoAssicurazione()} euro\n");
             


            }
            Console.WriteLine(
                 "Premi un tasto per uscire...");

        }
    }
}
*/
using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using static ConsoleApp1.Program;
namespace ConsoleApp1
{
    internal class Program
    {
        /*
         Obiettivo: implementare un sistema di gestione studenti utilizzando una classe Studente.

        Classe Studente:
        campi privati: nome, cognome, matricola, ArrayList di voti
        costruttore che inizializza tutti i dati
        proprietà di sola lettura per nome, cognome e matricola
        proprietà calcolata della Media (di sola lettura)
        proprietà calcolata del NumeroVoti (di sola lettura)
        metodi: AggiungiVoto(int), RimuoviUltimoVoto(), StampaLibretto(), ToString()

        Programma prevede...
        Creare un arrayList di Studente e implementare un menu così composto:
        Aggiungi studente
        Cerca per matricola
        Aggiungi voto a studente
        Visualizza tutti
        Trova studente con media più alta
        Esci
         */
        public class Studente
        {
            private string nome;
            private string cognome;
            private string matricola;
            private ArrayList voti;
            public Studente(string nome, string cognome, string matricola)
            {
                this.nome = nome;
                this.cognome = cognome;
                this.matricola = matricola;
                voti = new ArrayList();
            }
            public string Nome { get => nome; }
            public string Cognome { get => cognome; }
            public string Matricola { get => matricola; }
            public double Media
            {
                get
                {
                    if (voti.Count == 0) return 0.0;
                    double somma = 0.0;
                    foreach (int voto in voti)
                    {
                        somma += voto;
                    }
                    return somma / voti.Count;
                }
            }
            public int NumeroVoti { get => voti.Count; }
            public void AggiungiVoto(int voto)
            {
                voti.Add(voto);
            }
            public void RimuoviUltimoVoto()
            {
                if (voti.Count > 0)
                {
                    voti.RemoveAt(voti.Count - 1);
                }
            }
            public void StampaLibretto()
            {
                Console.WriteLine($"Libretto di {nome} {cognome} (Matricola: {matricola}):");
                foreach (int voto in voti)
                {
                    Console.WriteLine($"- Voto: {voto}");
                }
                Console.WriteLine($"Media: {Media}");
            }
            public override string ToString()
            {
                return $"{nome} {cognome} (Matricola: {matricola}) - Media: {Media}, Numero Voti: {NumeroVoti}";
            }
        }

      
        static void Main(string[] args)
        {

            ArrayList studenti = new ArrayList();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Aggiungi studente");
                Console.WriteLine("2. Cerca per matricola");
                Console.WriteLine("3. Aggiungi voto a studente");
                Console.WriteLine("4. Visualizza tutti");
                Console.WriteLine("5. Trova studente con media più alta");
                Console.WriteLine("6. Esci");
                Console.Write("Scegli un'opzione: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        aggiungiStudente();
                        break;
                    case "2":
                        findByMatricola();
                        break;
                    case "3":
                        addVoto();
                        break;
                    case "4":
                        viewAllStudents();
                        break;
                    case "5":
                        studenteMediaPiuAlta();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }




            }
            
            {
               

            }
            void aggiungiStudente()
                {
                Console.WriteLine("Inserisci nome dello studente:");
                string nome = Console.ReadLine();
                Console.WriteLine("Inserisci cognome dello studente:");
                string cognome = Console.ReadLine();
                Console.WriteLine("Inserisci matricola dello studente:");
                string matricola = Console.ReadLine();
                Studente nuovoStudente = new Studente(nome, cognome, matricola);
                studenti.Add(nuovoStudente);
                Console.WriteLine("Studente aggiunto con successo.");
            }
            void findByMatricola()
        {
            Console.WriteLine(
                "Inserisci matricola dello studente da cercare:");
            string matricola = Console.ReadLine();
            foreach (Studente s in studenti)
            {
                if (s.Matricola == matricola)                {
                    Console.WriteLine(s.ToString());
                    return;
                }
            }
            Console.WriteLine(
                "Studente non trovato.");
        }

         void addVoto()
        {
            Console.WriteLine(
                "Inserisci matricola dello studente a cui aggiungere un voto:");
            string matricola = Console.ReadLine();
            foreach (Studente s in studenti)
            {
                if (s.Matricola == matricola)
                {
                    Console.WriteLine(
                        "Inserisci il voto da aggiungere:");
                    int voto = int.Parse(Console.ReadLine());
                    s.AggiungiVoto(voto);
                    Console.WriteLine(
                        "Voto aggiunto con successo.");
                    return;
                }
            }
            Console.WriteLine(
                "Studente non trovato.");
        }
         void viewAllStudents()
        {
            Console.WriteLine(
                "Elenco di tutti gli studenti:");
            foreach (Studente s in studenti)
            {
                Console.WriteLine(s.ToString());
            }
        }
         void studenteMediaPiuAlta()
        {
            if (studenti.Count == 0)
            {
                Console.WriteLine(
                    "Nessuno studente presente.");
                return;
            }
            Studente topStudent = (Studente)studenti[0];
            foreach (Studente s in studenti)
            {
                if (s.Media > topStudent.Media)
                {
                    topStudent = s;
                }
            }
            Console.WriteLine(
                "Studente con la media più alta:");
            Console.WriteLine(topStudent.ToString());
            return;
        }
    }

       
       
}
}
