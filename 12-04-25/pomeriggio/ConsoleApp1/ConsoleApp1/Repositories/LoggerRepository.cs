using ConsoleApp1.Model;
using Microsoft.Data.SqlClient;
using System;

public class LoggerRepository
{
    public (bool LogStudenti, bool LogProfessori, bool LogCorsi, bool LogCodeStorico, string LogPath) CaricaConfig()
    {
        using (SqlConnection conn = ConnessioneSingleton.Instance.CreateConnection())
        {
            conn.Open();
            string query = "SELECT TOP 1 LogStudenti, LogProfessori, LogCorsi, LogCodeStorico, LogPath FROM LoggerConfig";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    bool logStudenti = reader.GetBoolean(0);
                    bool logProfessori = reader.GetBoolean(1);
                    bool logCorsi = reader.GetBoolean(2);
                    bool logCodeStorico = reader.GetBoolean(3);
                    string logPath = reader.IsDBNull(4) ? null : reader.GetString(4);

                    return (logStudenti, logProfessori, logCorsi, logCodeStorico, logPath);
                }
            }
        }

        // Default se non presente nel DB
        return (true, true, true, true, null);
    }

    public void SalvaConfig(bool logStudenti, bool logProfessori, bool logCorsi, bool logCodeStorico, string logPath)
    {
        using (SqlConnection conn = ConnessioneSingleton.Instance.CreateConnection())
        {
            conn.Open();
            string query = @"
                UPDATE LoggerConfig
                SET LogStudenti = @LogStudenti,
                    LogProfessori = @LogProfessori,
                    LogCorsi = @LogCorsi,
                    LogCodeStorico = @LogCodeStorico,
                    LogPath = @LogPath";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LogStudenti", logStudenti);
                cmd.Parameters.AddWithValue("@LogProfessori", logProfessori);
                cmd.Parameters.AddWithValue("@LogCorsi", logCorsi);
                cmd.Parameters.AddWithValue("@LogCodeStorico", logCodeStorico);
                cmd.Parameters.AddWithValue("@LogPath", logPath ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
