using Microsoft.Data.SqlClient;
using System;
using ConsoleApp1.Repositories;

public class LoggerRepository
{
    public LoggerConfig CaricaConfig()
    {
        using var conn = ConnessioneSingleton.Instance.CreateConnection();
        conn.Open();

        string query = "SELECT TOP 1 * FROM LoggerConfig";
        using var cmd = new SqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new LoggerConfig
            {
                Attivo = reader.GetBoolean(reader.GetOrdinal("Attivo")),
                LogStudenti = reader.GetBoolean(reader.GetOrdinal("LogStudenti")),
                LogProfessori = reader.GetBoolean(reader.GetOrdinal("LogProfessori")),
                LogCorsi = reader.GetBoolean(reader.GetOrdinal("LogCorsi")),
                LogCodeStorico = reader.GetBoolean(reader.GetOrdinal("LogCodeStorico")),
                UsaFile = reader.GetBoolean(reader.GetOrdinal("UsaFile")),
                UsaDatabase = reader.GetBoolean(reader.GetOrdinal("UsaDatabase")),
                FilePath = reader.IsDBNull(reader.GetOrdinal("FilePath"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("FilePath"))
            };
        }

        // default se non trovata
        return new LoggerConfig
        {
            Attivo = true,
            LogStudenti = true,
            LogProfessori = true,
            LogCorsi = true,
            LogCodeStorico = true,
            UsaFile = true,
            UsaDatabase = false,
            FilePath = null
        };
    }


    public void SalvaConfig(LoggerConfig c)
    {
        using var conn = ConnessioneSingleton.Instance.CreateConnection();
        conn.Open();

        string query = @"
            UPDATE LoggerConfig SET
                Attivo = @Attivo,
                LogStudenti = @LogStudenti,
                LogProfessori = @LogProfessori,
                LogCorsi = @LogCorsi,
                LogCodeStorico = @LogCodeStorico,
                UsaFile = @UsaFile,
                UsaDatabase = @UsaDatabase,
                FilePath = @FilePath";

        using var cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Attivo", c.Attivo);
        cmd.Parameters.AddWithValue("@LogStudenti", c.LogStudenti);
        cmd.Parameters.AddWithValue("@LogProfessori", c.LogProfessori);
        cmd.Parameters.AddWithValue("@LogCorsi", c.LogCorsi);
        cmd.Parameters.AddWithValue("@LogCodeStorico", c.LogCodeStorico);
        cmd.Parameters.AddWithValue("@UsaFile", c.UsaFile);
        cmd.Parameters.AddWithValue("@UsaDatabase", c.UsaDatabase);
        cmd.Parameters.AddWithValue("@FilePath", (object)c.FilePath ?? DBNull.Value);

        cmd.ExecuteNonQuery();
    }


    public void SalvaLogNelDB(DateTime timestamp, string categoria, string messaggio)
    {
        using var conn = ConnessioneSingleton.Instance.CreateConnection();
        conn.Open();

        string query = @"
            INSERT INTO LogEvents (Timestamp, Categoria, Messaggio)
            VALUES (@T, @C, @M)";

        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@T", timestamp);
        cmd.Parameters.AddWithValue("@C", categoria);
        cmd.Parameters.AddWithValue("@M", messaggio);

        cmd.ExecuteNonQuery();
    }
}
