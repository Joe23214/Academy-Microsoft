using System;
using System.Data.SqlClient;

public class DBConnection
{
    private static DBConnection instance;
    public static DBConnection Instance => instance ??= new DBConnection();

    private SqlConnection conn;

    private string _connectionString =
        "Server=localhost;Database=MioDB;User Id=sa;Password=YourPassword123;TrustServerCertificate=True;";

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public SqlConnection openConn()
    {
        try
        {
            conn = new SqlConnection(_connectionString);
            conn.Open();
            Console.WriteLine("Connessione stabilita!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Problema di connessione: " + ex.Message);
        }

        return conn;
    }

    public SqlConnection closeConn()
    {
        try
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("Connessione chiusa!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Problema di connessione: " + ex.Message);
        }

        return conn;
    }
}
