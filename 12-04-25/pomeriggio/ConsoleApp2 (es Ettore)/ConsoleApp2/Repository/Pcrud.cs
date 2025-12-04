using ConsoleApp2.Interafce;
using ConsoleApp2.Model;
using ConsoleApp2.View;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ConsoleApp2.Repository
{
    public class Pcrud : iCrud
    {
        MainView mainView = new MainView();

        public string createProdotto(Prodotto p)
        {
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                "INSERT INTO Prodotti(NOME_PRODOTTO,PREZZO,GIACENZA,CategoryId) VALUES(@NOME,@PREZZO,@GIACENZA,@CATID)", conn);
                cmd.Parameters.AddWithValue("@NOME", p.nome);
                cmd.Parameters.AddWithValue("@PREZZO", p.prezzo);
                cmd.Parameters.AddWithValue("@GIACENZA", p.giacenza);
                cmd.Parameters.AddWithValue("@CATID", p.CategoryId);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Prodotto Inserito con successo";
            }
            catch(Exception e) {

                return "Prodotto non inserito." + e.Message;
            }
        }
        public List<Prodotto> viewAll()
        {
            List<Prodotto> list = new List<Prodotto>();
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                "SELECT ID, NOME_PRODOTTO,PREZZO,GIACENZA, CategoryId  FROM Prodotti", conn);
                conn.Open();
                using var SqlReader = cmd.ExecuteReader();
                while (SqlReader.Read())
                {
                    list.Add(new Prodotto
                    {
                        id = SqlReader.GetInt32(0),
                        nome = SqlReader.GetString(1),
                        prezzo = (double) SqlReader.GetDecimal(2),
                        giacenza = SqlReader.GetInt32(3),
                        CategoryId = SqlReader.GetInt32(4)
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message );
                return list;
            }
        }
        public string updateProdotto(Prodotto pr)
        {
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {

                using var cmd = new SqlCommand(
                    "UPDATE Prodotti SET NOME_PRODOTTO = @NOME, PREZZO = @PREZZO, GIACENZA = @GIACENZA, CategoryId = @CATID WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", pr.id);
                cmd.Parameters.AddWithValue("@NOME", pr.nome);
                cmd.Parameters.AddWithValue("@PREZZO", pr.prezzo);
                cmd.Parameters.AddWithValue("@GIACENZA", pr.giacenza);
                cmd.Parameters.AddWithValue("@CATID", pr.CategoryId);
                conn.Open();
                cmd.ExecuteNonQuery();
                return $"Il prodotto con id {pr.id} è stato modificato con successo!";
            }
            catch (Exception e)
            {
               return "Prodotto non modificato!" + e.Message;
            }
        }
      

        public string deleteProdotto(Prodotto p)
        {
            using var conn = ConnessioneSingleton.Instance.CreateConnection();
            try
            {
                using var cmd = new SqlCommand(
                    "DELETE FROM Prodotti WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", p.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return "Il prodotto è stato eliminato!";
            }
            catch (Exception e)
            {
                return "Prodotto non eliminato!" + e.Message;
            }
        }
    }
}
