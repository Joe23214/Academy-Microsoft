using System;
using System.IO;

public sealed class Logger
{
    private static readonly Logger instance = new Logger();
    private string logPath;
    private readonly LoggerRepository repo = new LoggerRepository();

    public bool LogStudenti { get; set; }
    public bool LogProfessori { get; set; }
    public bool LogCorsi { get; set; }
    public bool LogCodeStorico { get; set; }

    private Logger()
    {
        // Path di default nella root progetto
        string bin = AppDomain.CurrentDomain.BaseDirectory;
        string projectRoot = Directory.GetParent(bin).Parent.Parent.Parent.FullName;
        string defaultPath = Path.Combine(projectRoot, "log_operazioni.txt");

        // Carica configurazione dal repository
        var config = repo.CaricaConfig();
        LogStudenti = config.LogStudenti;
        LogProfessori = config.LogProfessori;
        LogCorsi = config.LogCorsi;
        LogCodeStorico = config.LogCodeStorico;
        logPath = string.IsNullOrEmpty(config.LogPath) ? defaultPath : config.LogPath;

        // Crea file se non esiste
        if (!File.Exists(logPath))
            File.WriteAllText(logPath, "=== LOG CREATO ===\n");
    }

    public static Logger Instance => instance;

    public void Log(string message)
    {
        string riga = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  |  {message}";
        Console.WriteLine(riga);
        File.AppendAllText(logPath, riga + Environment.NewLine);
    }

    public void SalvaConfigSuDb()
    {
        repo.SalvaConfig(LogStudenti, LogProfessori, LogCorsi, LogCodeStorico, logPath);
    }

    public void AggiornaLogPath(string nuovoPath)
    {
        logPath = nuovoPath;
    }
}
