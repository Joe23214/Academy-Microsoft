using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Crud : iCrud
    {
        private readonly string connString;

        public Crud(string connectionString)
        {
            connString = connectionString;
        }

        public void CreaContatto(Contatto c)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "INSERT INTO Contatto (nome, cognome, indirizzo, citta, TdS) VALUES (@nome, @cognome, @indirizzo, @citta, @TdS)";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", c.nome);
            cmd.Parameters.AddWithValue("@cognome", c.cognome);
            cmd.Parameters.AddWithValue("@indirizzo", c.indirizzo);
            cmd.Parameters.AddWithValue("@citta", c.citta);
            cmd.Parameters.AddWithValue("@TdS", c.TdS);
            cmd.ExecuteNonQuery();
        }

        public void EliminaContatto(int id)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "DELETE FROM Contatto WHERE id = @id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void ModificaContatto(Contatto c)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = @"UPDATE Contatto 
                           SET nome=@nome, cognome=@cognome, indirizzo=@indirizzo, citta=@citta, TdS=@TdS 
                           WHERE id=@id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", c.nome);
            cmd.Parameters.AddWithValue("@cognome", c.cognome);
            cmd.Parameters.AddWithValue("@indirizzo", c.indirizzo);
            cmd.Parameters.AddWithValue("@citta", c.citta);
            cmd.Parameters.AddWithValue("@TdS", c.TdS);
            cmd.Parameters.AddWithValue("@id", c.id);
            cmd.ExecuteNonQuery();
        }

        public List<Contatto> FindAll()
        {
            List<Contatto> lista = new List<Contatto>();
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "SELECT id, nome, cognome, indirizzo, citta, TdS FROM Contatto";
            using var cmd = new SqlCommand(sql, con);
            using var rd = cmd.ExecuteReader();
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
            return lista;
        }

        public List<TitoloStudio> GetTitoliStudio()
        {
            List<TitoloStudio> lista = new List<TitoloStudio>();
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "SELECT Id, Titolo FROM TitoloStudio";
            using var cmd = new SqlCommand(sql, con);
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                lista.Add(new TitoloStudio
                {
                    Id = rd.GetInt32(0),
                    Titolo = rd.GetString(1)
                });
            }
            return lista;
        }

        public Contatto GetById(int id)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "SELECT id, nome, cognome, indirizzo, citta, TdS FROM Contatto WHERE id=@id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            using var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                return new Contatto
                {
                    id = rd.GetInt32(0),
                    nome = rd.GetString(1),
                    cognome = rd.GetString(2),
                    indirizzo = rd.GetString(3),
                    citta = rd.GetString(4),
                    TdS = rd.GetInt32(5)
                };
            }
            return null;
        }
    }
}
