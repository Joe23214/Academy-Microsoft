using ConsoleApp1;

public class LogService : ILoggerService
{
    private readonly Logger logger = Logger.Instance;

    public void Log(string categoria, string messaggio)
    {
        if (categoria.Equals("studenti", StringComparison.OrdinalIgnoreCase) && !logger.LogStudenti) return;
        if (categoria.Equals("professori", StringComparison.OrdinalIgnoreCase) && !logger.LogProfessori) return;
        if (categoria.Equals("corsi", StringComparison.OrdinalIgnoreCase) && !logger.LogCorsi) return;
        if (categoria.Equals("codestorico", StringComparison.OrdinalIgnoreCase) && !logger.LogCodeStorico) return;

        logger.Log(messaggio);
    }

    public void SalvaConfig()
    {
        logger.SalvaConfigSuDb();
    }

    public void AggiornaConfig(bool logStudenti, bool logProfessori, bool logCorsi, bool logCodeStorico)
    {
        logger.LogStudenti = logStudenti;
        logger.LogProfessori = logProfessori;
        logger.LogCorsi = logCorsi;
        logger.LogCodeStorico = logCodeStorico;
        SalvaConfig();
    }

    public void AggiornaLogPath(string nuovoPath)
    {
        logger.AggiornaLogPath(nuovoPath);
        SalvaConfig();
    }
}
