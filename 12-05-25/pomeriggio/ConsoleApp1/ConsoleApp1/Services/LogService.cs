using System;
using System.IO;

public sealed class LogService
{
    private static readonly LogService instance = new LogService();
    public static LogService Instance => instance;

    private LoggerConfig config;
    private readonly LoggerRepository repo = new LoggerRepository();

    private LogService()
    {
        config = repo.CaricaConfig();

        // Path di default se non presente
        if (string.IsNullOrEmpty(config.FilePath))
        {
            string bin = AppDomain.CurrentDomain.BaseDirectory;
            string root = Directory.GetParent(bin).Parent.Parent.Parent.FullName;
            config.FilePath = Path.Combine(root, "log_operazioni.txt");
        }
    }

    public void Log(string categoria, string messaggio)
    {
        if (!config.Attivo)
            return;

        if (!CategoriaPermessa(categoria))
            return;

        Logger log = new Logger
        {
            Id = DateTime.Now.Ticks,
            Categoria = categoria,
            Messaggio = messaggio,
            Timestamp = DateTime.Now
        };

        if (config.UsaFile)
            ScriviSuFile(log);

        if (config.UsaDatabase)
            repo.SalvaLogNelDB(log.Timestamp, log.Categoria, log.Messaggio);
    }


    private void ScriviSuFile(Logger log)
    {
        if (string.IsNullOrEmpty(config.FilePath))
            return;

        string row =
            $"{log.Id} | {log.Timestamp:yyyy-MM-dd HH:mm:ss} | {log.Categoria.ToUpper()} | {log.Messaggio}";

        File.AppendAllText(config.FilePath, row + Environment.NewLine);
    }


    private bool CategoriaPermessa(string c)
    {
        return c.ToLower() switch
        {
            "studenti" => config.LogStudenti,
            "professori" => config.LogProfessori,
            "corsi" => config.LogCorsi,
            "codestorico" => config.LogCodeStorico,
            _ => false
        };
    }


    //configurazioni

    public void ImpostaPath(string newPath)
    {
        config.FilePath = newPath;
        repo.SalvaConfig(config);
    }


    public void ImpostaOutput(bool file, bool db)
    {
        config.UsaFile = file;
        config.UsaDatabase = db;
        repo.SalvaConfig(config);
    }


    public void AttivaDisattivaLoggerGlobale(bool attivo)
    {
        config.Attivo = attivo;
        repo.SalvaConfig(config);
    }


    public void ImpostaCategoria(string nome, bool attivo)
    {
        switch (nome.ToLower())
        {
            case "studenti": config.LogStudenti = attivo; break;
            case "professori": config.LogProfessori = attivo; break;
            case "corsi": config.LogCorsi = attivo; break;
            case "codestorico": config.LogCodeStorico = attivo; break;
        }

        repo.SalvaConfig(config);
    }
}
