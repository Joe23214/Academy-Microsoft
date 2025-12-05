using System;
using System.IO;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Repositories
{
    public sealed class ConnessioneSingleton
    {
        private static readonly ConnessioneSingleton _instance = new ConnessioneSingleton();

        private string connectionString = string.Empty;

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

        public static ConnessioneSingleton Instance => _instance;

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
