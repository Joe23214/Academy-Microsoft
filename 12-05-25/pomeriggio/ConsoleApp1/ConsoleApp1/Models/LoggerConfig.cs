public class LoggerConfig
{
    /*
     CREATE TABLE LoggerConfig (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Attivo BIT NOT NULL,
    LogStudenti BIT NOT NULL,
    LogProfessori BIT NOT NULL,
    LogCorsi BIT NOT NULL,
    LogCodeStorico BIT NOT NULL,
    UsaFile BIT NOT NULL,
    UsaDatabase BIT NOT NULL,
    FilePath NVARCHAR(500) NULL
);

-- Inserimento riga iniziale
INSERT INTO LoggerConfig
(Attivo, LogStudenti, LogProfessori, LogCorsi, LogCodeStorico, UsaFile, UsaDatabase, FilePath)
VALUES
(1, 1, 1, 1, 1, 1, 0, NULL);
     */
    public bool Attivo { get; set; }
    public bool LogStudenti { get; set; }
    public bool LogProfessori { get; set; }
    public bool LogCorsi { get; set; }
    public bool LogCodeStorico { get; set; }

    public bool UsaFile { get; set; }
    public bool UsaDatabase { get; set; }

    public string FilePath { get; set; }
}
