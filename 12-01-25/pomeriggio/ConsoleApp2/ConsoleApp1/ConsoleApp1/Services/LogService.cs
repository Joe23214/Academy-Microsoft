using System;

namespace ConsoleApp1
{
    public class LogService
    {

        private readonly Logger logger = Logger.Instance;

        public void Log(string categoria, string messaggio)
        {
            if (categoria == "studenti" && !logger.LogStudenti) return;
            if (categoria == "professori" && !logger.LogProfessori) return;
            if (categoria == "corsi" && !logger.LogCorsi) return;
            if (categoria == "codestorico" && !logger.LogCodeStorico) return;

            logger.Log(messaggio);
        }

    }
}