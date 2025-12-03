using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
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

        public string deleteCategoria(Categoria c)
        {
            throw new NotImplementedException();
        }

        public string updateCategoria(Categoria c)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> viewAll()
        {
            throw new NotImplementedException();
        }
    }
}
