using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class UniversitàController
    {
        private readonly InterfacciaRepository repo;
        private readonly StoricoOperazioni storico = new StoricoOperazioni();
        private CodaIscrizioni codaIscrizioni = new CodaIscrizioni();
        private readonly Logger logger = Logger.Instance;


        public UniversitàController(InterfacciaRepository repository)
        {
            repo = repository;
        }

        public bool AggiungiStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            bool ok = repo.AggiungiStudente(nome.Trim(), cognome.Trim(), matricola, codiceCorso);
            string msg = $"Aggiunto studente {nome} {cognome} ({matricola}) al corso {codiceCorso}";
            if (ok)
                    storico.Registra(msg);
                logger.Log(msg);
            return ok;
        }

        public Studente CercaStudente(string matricola)
        {
            string msg = $"Ricerca studente {matricola}";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.CercaStudente(matricola);
        }

        public bool AggiungiVoto(string matricola, string materia, int voto)
        {
            bool ok = repo.AggiungiVoto(matricola, materia, voto);
            string msg = $"Aggiunto voto {voto} in {materia} allo studente {matricola}";
            if (ok)               
                    storico.Registra(msg);
                logger.Log(msg);
            return ok;
        }

        public Dictionary<string, int[]> GetVotiStudente(string matricola)
        {
            string msg = $"Richiesti voti per studente {matricola}";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.GetVotiStudente(matricola);
        }

        public IEnumerable<Studente> GetAllStudenti()
        {
            string msg = "Richiesta lista studenti";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.GetAllStudenti();
        }

        public Studente StudenteMediaPiuAlta()
        {
            string msg = "Ricerca studente con media più alta";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.StudenteMediaPiuAlta();
        }

        public bool AggiungiProfessore(string nome, string cognome, string id, string materia)
        {
            bool ok = repo.AggiungiProfessore(nome.Trim(), cognome.Trim(), id, materia);
            string msg = $"Aggiunto professore {nome} {cognome} ({id})";
            if (ok)
                    storico.Registra(msg);
                logger.Log(msg);
            return ok;
        }

        public Professore CercaProfessore(string id)
        {
            string msg = $"Ricerca professore {id}";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.CercaProfessore(id);
        }

        public bool AggiungiCorso(string codice, string nome)
        {
            bool ok = repo.AggiungiCorso(codice, nome.Trim());
             string msg = $"Aggiunto corso {nome} ({codice})";
            if (ok)
                storico.Registra(msg);
                 logger.Log(msg);
            return ok;
        }

        public CorsoDiLaurea CercaCorso(string codice)
        {
            string msg = $"Ricerca corso {codice}";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.CercaCorso(codice);
        }

        public bool AssegnaProfessoreACorso(string idProf, string codiceCorso)
        {
            bool ok = repo.AssegnaProfessoreACorso(idProf, codiceCorso);
            string msg = $"Assegnato prof {idProf} al corso {codiceCorso}";
            if (ok)
                    storico.Registra(msg);
                logger.Log(msg);
            return ok;
        }

        public IEnumerable<CorsoDiLaurea> GetAllCorsi()
        {
            string msg = "Richiesta lista corsi";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.GetAllCorsi();
        }

        public string StampaLibretto(string matricola)
        {
            string msg = $"Stampa libretto {matricola}";
                storico.Registra(msg);
            logger.Log(msg);
            return repo.StampaLibretto(matricola);
        }

        public bool AggiungiMateriaACorso(string codiceCorso, string materia)
        {
            bool ok = repo.AggiungiMateriaACorso(codiceCorso, materia);
            string msg = $"Aggiunta materia {materia} al corso {codiceCorso}";
            if (ok)
                    storico.Registra(msg);
                logger.Log(msg);
            return ok;
        }

        public List<Studente> OrdinaStudentiPerMedia()
        {
            string msg = "Ordinamento studenti per media";
                storico.Registra(msg);
            logger.Log(msg);
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
            if (s == null)
            {
                Console.WriteLine("Studente non trovato.");
                return;
            }

            foreach (var stud in codaIscrizioni.OttieniRichiesteInAttesa())
            {
                if (stud.Matricola == matricola)
                {
                    Console.WriteLine("Errore: studente già in coda.");
                    return;
                }
            }

            codaIscrizioni.AggiungiRichiesta(s);
            string msg = $"Richiesta di {s.Nome} {s.Cognome} aggiunta in coda.";
            Console.WriteLine(msg);

        }


        public Studente ApprovaRichiesta()
        {
            var studente = codaIscrizioni.ApprovaProssima();
            if (studente == null)
                return null;

            if (repo.CercaStudente(studente.Matricola) != null)
            {
                Console.WriteLine($"Errore: lo studente {studente.Matricola} è già nel repository.");
                return null;
            }


            repo.AggiungiStudente(
                studente.Nome,
                studente.Cognome,
                studente.Matricola,
                studente.CorsoIscritto.Codice
            );

            string msg = $"studente nome: {studente.Nome} cognome: {studente.Cognome} matricola: {studente.Matricola} approvato!";
            storico.Registra(msg);
            logger.Log(msg);
            return studente;
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

        public bool RichiestaNuovoStudente(string nome, string cognome, string matricola, string codiceCorso)
        {
            
            if (repo.CercaStudente(matricola) != null)
            {
                Console.WriteLine("Errore: matricola già esistente nel sistema.");
                return false;
            }

            
            var corso = repo.CercaCorso(codiceCorso);
            if (corso == null)
            {
                Console.WriteLine("Errore: corso non trovato.");
                return false;
            }

           
            var studente = new Studente(nome, cognome, matricola)
            {
                CorsoIscritto = corso
            };

            try
            {
                codaIscrizioni.AggiungiRichiesta(studente);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            Console.WriteLine($"Richiesta di iscrizione per {nome} {cognome} aggiunta in coda.");
            return true;
        }

    }
}
