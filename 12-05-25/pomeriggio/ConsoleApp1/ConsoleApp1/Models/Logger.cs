using System;
using System.IO;

public class Logger
{
    /*
     CREATE TABLE LogEvents (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Timestamp DATETIME NOT NULL,
    Categoria NVARCHAR(50) NOT NULL,
    Messaggio NVARCHAR(MAX) NOT NULL
);


     */

    public long Id { get; set; }
    public string Categoria { get; set; }
    public string Messaggio { get; set; }
    public DateTime Timestamp { get; set; }
}
