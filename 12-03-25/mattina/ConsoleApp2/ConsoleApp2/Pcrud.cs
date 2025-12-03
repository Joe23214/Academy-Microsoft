using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Pcrud : iCrud
    {
        MainView mainView = new MainView();
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=NEGOZIODB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Prodotti createProdotto(Prodotti p)
        {
            string querystringa = "INSERT INTO PRODOTTI (NOME_PRODOTTO, PREZZO, GIACENZA) VALUES(@NOME,@PREZZO,@GIACENZA)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(querystringa, connection))
                {
                    cmd.Parameters.AddWithValue("@NOME", p.nome);
                    cmd.Parameters.AddWithValue("@PREZZO", p.prezzo);
                    cmd.Parameters.AddWithValue("@GIACENZA", p.giacenza);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"finite inserimento! nome: {p.nome},prezzo {p.prezzo}, giacenza {p.giacenza}. ");
                }
            }
            return p;
        }

        public Prodotti deleteProdotto(Prodotti p)
        {
            throw new NotImplementedException();
        }

        public Prodotti findByIdProdotto(int i)
        {
            throw new NotImplementedException();
        }

        public Prodotti updateProdotto(Prodotti p)
        {
            throw new NotImplementedException();
        }

        public void viewAll()
        {
            throw new NotImplementedException();
        }
    }
}
