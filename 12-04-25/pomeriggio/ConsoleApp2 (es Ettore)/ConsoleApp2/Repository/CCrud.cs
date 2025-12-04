using ConsoleApp2.Interafce;
using ConsoleApp2.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Repository
{
    public class CCrud : IcCrud
    {
        public string createCategoria(Categoria c)
        {
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                "INSERT INTO Categorie(CATEGORIA) VALUES(@CATEGORIA)", conn);
                cmd.Parameters.AddWithValue("@CATEGORIA", c.TipoCategoria);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Categoria Inserita con successo";
            }
            catch (Exception e)
            {

                return "Categoria non inserita." + e.Message;
            }
        }

        public string updateCategoria(Categoria c)
        {
            
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {

                using var cmd = new SqlCommand(
                    "UPDATE Categorie SET CATEGORIA = @CATEGORIA WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", c.Id);
                cmd.Parameters.AddWithValue("@CATEGORIA", c.TipoCategoria);
                conn.Open();
                cmd.ExecuteNonQuery();
                return $"Il prodotto con id {c.Id} è stato modificato con successo!";
            }
            catch (Exception e)
            {
                return "Prodotto non modificato!" + e.Message;
            }
        }
        

        public List<Categoria> viewAll()
        {
            List<Categoria> list = new List<Categoria>();
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                "SELECT ID, CATEGORIA  FROM Categorie", conn);
                conn.Open();
                using var SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    list.Add(new Categoria
                    {
                        Id = SqlReader.GetInt32(0),
                        TipoCategoria = SqlReader.GetString(1),
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return list;
            }
        }

        public string deleteCategoria(Categoria c)
        {
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                    "DELETE FROM Categorie WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", c.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "La categoria è stata eliminata!";
            }
            catch (Exception e)
            {
                return "Categoria non eliminata!" + e.Message;
            }
        }
    }

}


