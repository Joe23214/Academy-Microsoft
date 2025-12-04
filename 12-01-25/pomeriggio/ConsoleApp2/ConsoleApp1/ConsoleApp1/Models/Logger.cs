using System;
using System.IO;

namespace ConsoleApp1
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();   // per singleton
        private readonly string logPath;
        public bool LogStudenti { get; set; } = true;
        public bool LogProfessori { get; set; } = true;
        public bool LogCorsi { get; set; } = true;
        public bool LogCodeStorico { get; set; } = true;
        
        // Costruttore privato, no new
        private Logger()
        {
            logPath = "C:\\Users\\giova\\Desktop\\log_operazioni.txt";
        }

        public static Logger Instance => instance;

        public void Log(string message)
        {
            string riga = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  |  {message}";
            Console.WriteLine(riga);              
            File.AppendAllText(logPath, riga + Environment.NewLine);
        }
    }
}
