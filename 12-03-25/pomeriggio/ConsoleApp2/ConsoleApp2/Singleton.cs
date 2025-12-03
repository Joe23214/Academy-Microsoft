/*
namespace ConsoleApp2
{
	//classe Singleton di tipo sealed non ereditabile
	public sealed class Singleton
	{
		//membro privato che rappresenta l'instanza della classe
		private static Singleton _instance;

		//costruttore privato senza parametri non accessibile dall'esterno della classe
		private Singleton() { }

		//Entry-Point: proprietà esterna che ritorna l'istanza della classe
		public static Singleton Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Singleton();
				}
				return _instance;
			}
		}
		private readonly string connectionString = ...;
public sqlConnection CreateConnection(){
return new sqlConnection(connectionString)
}
}


Class Program
		{
static void Main(string[] args)
		{
			Singleton s1 = Singleton.Instance;
			Singleton s2 = Singleton.Instance;
			if (s1 == s2)
				Console.WriteLine("Instanza Singleton Unica");
			else
				Console.WriteLine("Instanza Singleton Differente");

			Console.ReadLine();
		}
	}
}

Versione trhead safe:

Pattern Singleton thread-safety – (adv) facoltativa
Per essere certi che il pattern Singleton sia thread-safe il codice và modificato in questo modo:
//classe Singleton di tipo sealed non ereditabile

public sealed class Singleton
{
	//membro privato che rappresenta l'instanza della classe
	private static Singleton _instance;

	//membro privato per la sincronizzazione dei thread
	private static readonly Object _sync = new Object();

	//costruttore privato non accessibile dall'esterno della classe
	private Singleton() { }
	//Entry-Point: proprietà esterna che ritorna l'istanza della classe
	public static Singleton Instance
	{
		get
		{
			//per evitare richieste di lock successive alla prima istanza
			if (_instance == null)
			{
				lock (_sync) //area critica per la sincronizz dei thread
				{
					//vale sempre per la prima istanza
					if (_instance == null)
					{
						_instance = new Singleton();
					}
				}
			}
			return _instance;
		}
	}
}


In questa seconda implementazione il pattern Singleton è thread safety infatti l'area critica definita dalla parola chiave lock* assicura un'esclusione reciproca per ogni thread, 
inoltre nell'entry-point viene messo un doppio controllo sull'istanza, il secondo if, quello più esterno è stato aggiunto per evitare che il lock sia richiamato ogni volta che un thread invoca la proprietà,
comportando un'assurdo spreco di risorse, con questo ulteriore if invece il lock viene attivato solo alla creazione della prima istanza.

*: L'istruzione lock impedisce a un thread di accedere a una sezione critica del codice, mentre un altro thread è già presente in tale sezione. 
*Se un altro thread tenta di accedere a un codice bloccato, attenderà (in stato di blocco) finché l'oggetto non verrà rilasciato (MSDN).
**/