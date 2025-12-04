using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2.Model
{
    //classe Singleton di tipo sealed non ereditabile
    public sealed class ConnessioneSingleton
    {
        //membro privato che rappresenta l'instanza della classe
        private static ConnessioneSingleton _instance;

        private string connectionString;

        //costruttore privato senza parametri non accessibile dall'esterno della classe
        private ConnessioneSingleton() {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "connection.txt");
            if (File.Exists(path))
            {
                connectionString = File.ReadAllText(path);
            }
            else
            {
                throw new FileNotFoundException($"File di connessione non trovato: {path}");
            }
        }

        //Entry-Point: proprietà esterna che ritorna l'istanza della classe
        public static ConnessioneSingleton Instance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new ConnessioneSingleton();
                }
                return _instance;
            }
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}