using System;
using ConsoleApp2;
using Microsoft.Data.SqlClient;

namespace MyApp
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            MainView mw = new MainView();
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=NEGOZIODB;Trusted_Connection=True;TrustServerCertificate=True;";

            string strquery = "SELECT * FROM Prodotti";
            try
            {
                //creare connessione a db
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connessione aperta con successo");
                    using (SqlCommand cmd = new SqlCommand(strquery, connection))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            //finchè legge
                            while (reader.Read())
                            {
                                //reader legge esattamente il nome della colonna
                                Console.WriteLine($"ID:  {reader["ID"]}, NOME: {reader["NOME_PRODOTTO"]} PREZZO: {reader["PREZZO"]} ");
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                //esegue se non riesce ad eseguire try
                Console.WriteLine("Catch se non eseguo try ");
                Console.WriteLine("Errore generico : " + e.Message);
            }
            finally
            {
                //viene sempre eseguito dopo il blocco try o catch
                Console.WriteLine("Eseguo sempre");
                Pcrud x = new Pcrud();
                mw.CreateProdotto();
            }

        }
    }
}