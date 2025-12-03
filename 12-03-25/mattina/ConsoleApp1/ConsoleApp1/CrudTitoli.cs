using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class CrudTitoli : iCrudTitoli
    {
        private readonly string connString;

        public CrudTitoli(string connectionString)
        {
            connString = connectionString;
        }

        public void CreaTitolo(TitoloStudio t)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "INSERT INTO TitoloStudio (Titolo) VALUES (@titolo)";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@titolo", t.Titolo);
            cmd.ExecuteNonQuery();
        }

        public void ModificaTitolo(TitoloStudio t)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "UPDATE TitoloStudio SET Titolo=@titolo WHERE Id=@id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@titolo", t.Titolo);
            cmd.Parameters.AddWithValue("@id", t.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminaTitolo(int id)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "DELETE FROM TitoloStudio WHERE Id=@id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<TitoloStudio> FindAll()
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

        public TitoloStudio? GetById(int id)
        {
            using var con = new SqlConnection(connString);
            con.Open();
            string sql = "SELECT Id, Titolo FROM TitoloStudio WHERE Id=@id";
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            using var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                return new TitoloStudio
                {
                    Id = rd.GetInt32(0),
                    Titolo = rd.GetString(1)
                };
            }
            return null;
        }
    }
}
