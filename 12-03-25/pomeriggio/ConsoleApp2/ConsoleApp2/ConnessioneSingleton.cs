using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp2
{
    //classe Singleton di tipo sealed non ereditabile
    public sealed class ConnessioneSingleton
    {
        //membro privato che rappresenta l'instanza della classe
        private static ConnessioneSingleton _instance;

        //costruttore privato senza parametri non accessibile dall'esterno della classe
        private ConnessioneSingleton() { }

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
        private readonly string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=NEGOZIODB;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}