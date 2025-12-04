using System;

namespace ConsoleApp1
{
    public interface ILoggerService
    {
        void Log(string categoria, string messaggio);
        void SalvaConfig();
        void AggiornaConfig(bool logStudenti, bool logProfessori, bool logCorsi, bool logCodeStorico);
        void AggiornaLogPath(string nuovoPath);
    }


}