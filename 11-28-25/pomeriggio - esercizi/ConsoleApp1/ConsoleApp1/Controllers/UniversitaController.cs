using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class UniversitàController
    {
        private readonly InterfacciaRepository repo;
        private readonly StoricoOperazioni storico = new StoricoOperazioni();
        private CodaIscrizioni codaIscrizioni = new CodaIscrizioni();


        public UniversitàController(InterfacciaRepository repository)
        {
            repo = repository;
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            bool ok = repo.AggiungiStudente(nome.Trim(), cognome.Trim(), matricola, codiceCorso);
            if (ok)
                storico.Registra($"Aggiunto studente {nome} {cognome} ({matricola}) al corso {codiceCorso}");
            return ok;
        }

        public Studente CercaStudente(string matricola)
        {
            storico.Registra($"Ricerca studente {matricola}");
            return repo.CercaStudente(matricola);
        }

        public bool AggiungiVoto(string matricola, string materia, int voto)
        {
            bool ok = repo.AggiungiVoto(matricola, materia, voto);
            if (ok)
                storico.Registra($"Aggiunto voto {voto} in {materia} allo studente {matricola}");
            return ok;
        }

        public Dictionary<string, int[]> GetVotiStudente(string matricola)
        {
            storico.Registra($"Richiesti voti per studente {matricola}");
            return repo.GetVotiStudente(matricola);
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            storico.Registra("Richiesta lista studenti");
            return repo.GetAllStudenti();
        }

        public Studente StudenteMediaPiuAlta()
        {
            storico.Registra("Ricerca studente con media più alta");
            return repo.StudenteMediaPiuAlta();
        }

        public bool AggiungiProfessore(string nome, string cognome, string id, string materia)
        {
            bool ok = repo.AggiungiProfessore(nome.Trim(), cognome.Trim(), id, materia);
            if (ok)
                storico.Registra($"Aggiunto professore {nome} {cognome} ({id})");
            return ok;
        }

        public Professore CercaProfessore(string id)
        {
            storico.Registra($"Ricerca professore {id}");
            return repo.CercaProfessore(id);
        }

        public bool AggiungiCorso(string codice, string nome)
        {
            bool ok = repo.AggiungiCorso(codice, nome.Trim());
            if (ok)
                storico.Registra($"Aggiunto corso {nome} ({codice})");
            return ok;
        }

        public CorsoDiLaurea CercaCorso(string codice)
        {
            storico.Registra($"Ricerca corso {codice}");
            return repo.CercaCorso(codice);
        }

        public bool AssegnaProfessoreACorso(string idProf, string codiceCorso)
        {
            bool ok = repo.AssegnaProfessoreACorso(idProf, codiceCorso);
            if (ok)
                storico.Registra($"Assegnato prof {idProf} al corso {codiceCorso}");
            return ok;
        }

        public IEnumerable<CorsoDiLaurea> GetAllCorsi()
        {
            storico.Registra("Richiesta lista corsi");
            return repo.GetAllCorsi();
        }

        public string StampaLibretto(string matricola)
        {
            storico.Registra($"Stampa libretto {matricola}");
            return repo.StampaLibretto(matricola);
        }

        public bool AggiungiMateriaACorso(string codiceCorso, string materia)
        {
            bool ok = repo.AggiungiMateriaACorso(codiceCorso, materia);
            if (ok)
                storico.Registra($"Aggiunta materia {materia} al corso {codiceCorso}");
            return ok;
        }

        public List<Studente> OrdinaStudentiPerMedia()
        {
            storico.Registra("Ordinamento studenti per media");
            return repo.OrdinaStudentiPerMedia();
        }

        //Operazioni storico 
        public string UltimaOperazione() => storico.UltimaOperazione();
        public string AnnullaUltimaOperazione() => storico.Annulla();
        public List<string> GetStoricoCompleto() => storico.OttieniTutte();
        public int NumeroOperazioni => storico.Count;

        //Operazioni coda
        public void AggiungiRichiestaIscrizione(string matricola)
        {
            var s = repo.CercaStudente(matricola);
            if (s != null)
                codaIscrizioni.AggiungiRichiesta(s);
        }

        public Studente ApprovaRichiesta()
        {
            return codaIscrizioni.ApprovaProssima();
        }

        public List<Studente> RichiesteInAttesa()
        {
            return codaIscrizioni.OttieniRichiesteInAttesa();
        }

        public Studente ProssimoInCoda() => codaIscrizioni.ProssimoInCoda();
        public int NumeroRichieste => codaIscrizioni.NumeroRichieste;


        public void TestGenericRepo()
        {
            var repo = new RepositoryGenerico<Studente1>();

            var s1 = new Studente1 { Nome = "Mario", Cognome = "Rossi", Matricola = "S001" };
            var s2 = new Studente1 { Nome = "Luca", Cognome = "Bianchi", Matricola = "S002" };
            var s3 = new Studente1 { Nome = "Anna", Cognome = "Verdi", Matricola = "S003" };

            Console.WriteLine("Aggiungo studenti...");
            repo.Aggiungi(s1);
            repo.Aggiungi(s2);
            repo.Aggiungi(s3);

            Console.WriteLine($"Totale studenti nel repository: {repo.Count}");
            foreach (var stud in repo.GetAll())
                Console.WriteLine(stud);

            Console.WriteLine("\nModifico studente S002 (Cognome -> Neri)...");
            s2.Cognome = "Neri";
            repo.Aggiorna(s2);
            Console.WriteLine(repo.GetById("S002"));

            Console.WriteLine("\nRimuovo studente S003...");
            repo.Rimuovi("S003");
            Console.WriteLine($"Totale studenti nel repository: {repo.Count}");
            foreach (var stud in repo.GetAll())
                Console.WriteLine(stud);

            Console.WriteLine("\nTest completato.");
        }

    }
}
