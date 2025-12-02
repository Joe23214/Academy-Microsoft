using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;


namespace ConsoleApp1
{
    internal class StRepository
    {
        private string connString;

        public StRepository(string connectionString)
        {
            connString = connectionString;
        }

        public List<Contatto> FindAll()
        {
            List<Contatto> lista = new List<Contatto>();

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string sql = "SELECT id, nome, cognome, indirizzo, citta, TdS FROM Contatto";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    lista.Add(new Contatto
                    {
                        id = rd.GetInt32(0),
                        nome = rd.GetString(1),
                        cognome = rd.GetString(2),
                        indirizzo = rd.GetString(3),
                        citta = rd.GetString(4),
                        TdS = rd.GetInt32(5)
                    });
                }
            }

            return lista;
        }
    }
}
