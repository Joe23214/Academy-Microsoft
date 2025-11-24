/*
 fondamenti OOP in C#
1) INCAPSULAMENTO:  Possibilità di nascondere i dettagli interni di un oggetto e di esporre solo ciò che è necessario attraverso metodi pubblici gli attributi saranno privati. Questo aiuta a proteggere lo stato interno dell'oggetto e a prevenire modifiche indesiderate.
2) Astrazione: rappresenta ciò che serve. nasconde complesstà non necessaria.
esempio:
un auto ha il metood avvia(); non è necessario conoscere come funziona;
3) Ereditarietà: una classe può ereditare caratteristiche da un'altra classe

esempio: Classe Aniamle
la classe Cane eredita da animale

4) Polimorfismo: oggetti differenti possono risdpondere allo stesso messaggio in modo diverso
esempio: emetteSuono();
Cane: abbaia;
Gatto: miagola;

Classe:
e' un modello, un progetto, un tipo di dato(astratto)
Contiene:
Attributi: (dati) rappresentano lo stato dell'oggetto
Metodi: (funzioni) rappresentano il comportamento dell'oggetto

oggetto: è un istanza della classe

costruttore: metodo speciale che viene chiamato quando si crea un oggetto della classe e viene chiamato per instanziare un oggetto.
Public class Persona{
public string nome,
public string cognome;
public int eta;
public void Saluta(){
COnsole.writeLine($"Ciao, sono " + nome + " " + cognome + " e ho " + eta + " anni.");

Public static void Main (){
int z;
double x;
Persona p1 = new Persona(); ->  viene invocato il costruttore
p1.nome = "Mario";
p1.cognome = "Rossi";
p1.eta = 30;
p1.Saluta();

}



public class Persona {
    // Attributi
    private string nome;
    private string cognome;
    private int eta;
    // Costruttore
    public Persona(string nome, string cognome, int eta){
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }
// costruttore base o di default.(predefinito)
    public Persona();
   public Persona(string nome,string cognome, string eta){
        this.nome = nome;
        this.cognome = " ";
        this.eta = 0;
    // Metodo pubblico per salutare
    public void Saluta(){
        Console.WriteLine($"Ciao, sono " + nome + " " + cognome + " e ho " + eta + " anni.");
    }
    public int getEta(){
        return eta;
    }
    public void setEta(int nuovaEta){
        if(eta >= 0){ //-> potremmo aggiungere controllie  customizzarla
            this.eta = eta;
        } else {
            Console.WriteLine("L'età non può essere negativa.");
        }
    }


 }
Public static void Main (){
Persona p1 = new Persona("Giovanni","Pontrelli",26); 

Persona p2 = new Persona("Francesca","Rossi",22);

Persona p3 = new Persona();
//metodi pubblici
p1.Saluta(); -> Ciao, sono Giovanni Pontrelli e ho 26 anni.
p2.Saluta(); -> Ciao, sono Francesca Rossi e ho 22 anni.
p3.Saluta(); -> Ciao, sono   e ho 0 anni.

}


 */


using System;
namespace ConsoleApp1
{
    internal class mainClass
    {
       

             public class Automobile
        {
            private string marca;
            private string modello;
            private int anno;
            private string suono;

            public Automobile(string marca, string modello, int anno, string suono)
            {
                this.marca = marca;
                this.modello = modello;
                this.anno = anno;
                this.suono = suono;
            }
            public Automobile() { }

            public void Avvia()
            {
                Console.WriteLine($"L'auto {marca} {modello} del {anno} emette il suono: {suono}");
            }
            public void setMarca(string nuovaMarca)
            {
                this.marca = nuovaMarca;
            }
            public string getMarca()
            {
                return this.marca;
            }
            public string getModello()
            {
                return this.modello;
            }
            public void setModello(string nuovoModello)
            {
                this.modello = nuovoModello;
            }
            public int getAnno()
            {
                return this.anno;
            }
            public void setAnno(int nuovoAnno)
            {
                this.anno = nuovoAnno;
            }
            public void setSuono(string nuovoSuono)
            {
                this.suono = nuovoSuono;
            }

            public void suona()
            {
                Console.WriteLine(suono);

            }

            public override string ToString()
            {
                //  return base.ToString(); // eredita da Object
                return $"Automobile: {marca} {modello} {anno} Suono: {suono}";

            }
        }
        public class Persona
        {
            private string nome;
            private string cognome;
            private DateTime dataNascita;

            public Persona(string nome, string cognome, DateTime dataNascita)
            {
                this.nome = nome;
                this.cognome = cognome;
                this.dataNascita = dataNascita;
            }

            //costruttore moderno
            public Persona (string nome, string cognome) => (this.nome, this.cognome, this.dataNascita) = (nome, cognome, DateTime.Now);

            public Persona() { }

            //ghetters and setters
        
            public string getNome()
            {
                return this.nome;
            }
            public void setNome(string nuovoNome)
            {
                this.nome = nuovoNome;
            }
            public string getCognome()
            {
                return this.cognome;
            }
            public void setCognome(string nuovoCognome)
            {
                this.cognome = nuovoCognome;
            }
            public DateTime getDataNascita()
            {
                return this.dataNascita;
            }
            public void setDataNascita(DateTime nuovaDataNascita)
            {
                this.dataNascita = nuovaDataNascita;
            }

            //toString override
            public override string ToString()
            {
                return $"Persona: {nome} {cognome}, Nata il: {dataNascita.ToShortDateString()}";
            }

            //mewtodo per calcolare l'età
            public int CalcolaEta()
            {
                int eta = DateTime.Now.Year - dataNascita.Year;
                if (DateTime.Now.DayOfYear < dataNascita.DayOfYear)
                    eta--;
                return eta;
            }

            public Boolean MaggioreEta()
            {
                return CalcolaEta() >= 18;
            }

        }
        //ereditarietà
        public class Persona1
        {
            private string name;

            public string getName()
            {
                return this.name;
            }
            public void setName(string newName)
            {
                this.name = newName;
            }
            public Persona1() { }
            public void saluta()
            {
                Console.WriteLine($"Ciao, sono {name}");
            }
            //toString classe base
            public void toString()
            {
                Console.WriteLine($"Persona: {name}");
            }

        }
        public class Studente : Persona1
        {
            private string matricola;
            public string getMatricola()
            {
                return this.matricola;
            }
            public void setMatricola(string newMatricola)
            {
                this.matricola = newMatricola;
            }
            public Studente(string nome, string matricola)
            {
                setName(nome);
                this.matricola = matricola;
            }
            public Studente() { }
            public void studia()
            {
               Console.WriteLine($"Lo studente {getName()} sta studiando OOP.");
            }
            //override toString ereditato da Persona1
            public override string ToString()
            {
                return $"Studente: {getName()}, Matricola: {matricola}";
            }
        }
        static void Main(string[] args)
        {
            Automobile auto = new Automobile("Fiat", "Panda", 2020, "Beep Beep");
            Automobile auto1 = new Automobile();
            auto1.setMarca("Ford");
            auto1.setModello("Focus");
            auto1.setAnno(2018);
            auto1.setSuono("Tuut Tuut");
            auto.Avvia();
            auto1.Avvia();
            auto.suona();
            auto1.suona();
            Console.WriteLine("Modifico il suono delle auto...");
            auto1.setSuono("Broom Broom");
            auto.setSuono("Vroom Vroom");
            auto.suona();
            auto1.suona();
            auto.ToString();
            auto1.ToString();

            Persona p1 = new Persona("Luca", "Bianchi", new DateTime(2000, 5, 15));
            Persona p2 = new Persona();
            p2.setNome("Anna");
            p2.setCognome("Verdi");
            p2.setDataNascita(new DateTime(2010, 8, 22));
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine($"{p1.getNome()} ha {p1.CalcolaEta()} anni. Maggiore età: {p1.MaggioreEta()}");
            Console.WriteLine($"{p2.getNome()} ha {p2.CalcolaEta()} anni. Maggiore età: {p2.MaggioreEta()}");


            Persona1 px = new Persona1();
            px.setName("Marco");
            px.saluta();
            px.toString();
            Studente sx = new Studente();
            sx.setName("Giulia");
            sx.setMatricola("2023001");
            sx.saluta();
            sx.toString();
            //anche qui non ci sarà il tostring di object

            Object sxo = new Studente();
            sxo.ToString(); //polimorfismo -> chiamerà il tostring di studente
            //toString stuente  
            Persona1 pp1n = new Studente(); //polimorfismo
            Persona1.studia(); //non funziona perchè studia non è definito in persona1
            //con down-casting invece funziona
            //fare sempre il controllo con is
                ((Studente)pp1n).studia();





        }
    }
}

