using System;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Model
{
    public sealed class ConnessioneSingleton
    {
        private static ConnessioneSingleton _instance;

        private string connectionString;

        private ConnessioneSingleton()
        {
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