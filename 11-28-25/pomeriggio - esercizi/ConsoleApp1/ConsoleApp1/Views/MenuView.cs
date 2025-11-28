using System;

namespace ConsoleApp1.Views
{
    internal class MenuView
    {
        private UniversitàController controller;

        public MenuView(UniversitàController ctrl)
        {
            controller = ctrl;
        }

        public void Start()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Aggiungi Professore");
                Console.WriteLine("2. Aggiungi Corso");
                Console.WriteLine("3. Assegna Professore a Corso");
                Console.WriteLine("4. Aggiungi Studente");
                Console.WriteLine("5. Aggiungi Voto");
                Console.WriteLine("6. Visualizza tutti gli studenti");
                Console.WriteLine("7. Studente con media più alta");
                Console.WriteLine("8. Cerca studente per matricola");
                Console.WriteLine("9. Stampa libretto studente");
                Console.WriteLine("10. Ordina studenti per media");
                Console.WriteLine("11. Mostra ultima operazione");
                Console.WriteLine("12. Annulla ultima operazione");
                Console.WriteLine("13. Mostra TUTTO lo storico");
                Console.WriteLine("14. Aggiungi richiesta iscrizione in coda");
                Console.WriteLine("15. Approva prossima richiesta");
                Console.WriteLine("16. Mostra richieste in attesa");
                Console.WriteLine("17. Prossimo studente in coda");
                Console.WriteLine("18. Numero richieste in coda");
                Console.WriteLine("19. Test GenericRepo");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");

                switch (Console.ReadLine())
                {
                    case "0": exit = true; break;
                    case "1": AggiungiProfessore(); break;
                    case "2": AggiungiCorso(); break;
                    case "3": AssegnaProfessoreACorso(); break;
                    case "4": AggiungiStudente(); break;
                    case "5": AggiungiVoto(); break;
                    case "6": VisualizzaStudenti(); break;
                    case "7": MediaPiuAlta(); break;
                    case "8": CercaStudente(); break;
                    case "9": StampaLibretto(); break;
                    case "10": OrdinaStudenti(); break;
                    case "11": Console.WriteLine(controller.UltimaOperazione()); break;
                    case "12": Console.WriteLine(controller.AnnullaUltimaOperazione()); break;
                    case "13":
                        foreach (string op in controller.GetStoricoCompleto())
                            Console.WriteLine(op);
                        break;
                    case "14": AggiungiRichiestaCoda(); break;
                    case "15": ApprovaProssimaRichiesta(); break;
                    case "16": MostraRichiesteInAttesa(); break;
                    case "17": MostraProssimoInCoda(); break;
                    case "18": MostraNumeroRichieste(); break;
                    case "19": testGenericRepo(); break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }

        private void AggiungiProfessore()
        {
            Console.Write("Nome: "); string n = Console.ReadLine().Trim();
            Console.Write("Cognome: "); string c = Console.ReadLine().Trim();
            Console.Write("ID: "); string id = Console.ReadLine().Trim().ToUpperInvariant();
            Console.Write("Materia: "); string m = Console.ReadLine().Trim().ToUpperInvariant();

            if (controller.AggiungiProfessore(n, c, id, m))
                Console.WriteLine("Professore aggiunto.");
            else
                Console.WriteLine("Errore: ID già esistente.");
        }

        private void AggiungiCorso()
        {
            Console.Write("Codice corso: "); string cod = Console.ReadLine().Trim().ToUpperInvariant();
            Console.Write("Nome corso: "); string nome = Console.ReadLine().Trim();

            if (controller.AggiungiCorso(cod, nome))
            {
                Console.Write("Quante materie vuoi aggiungere? ");
                if (int.TryParse(Console.ReadLine(), out int nMat))
                {
                    for (int i = 0; i < nMat; i++)
                    {
                        Console.Write($"Materia {i + 1}: ");
                        string mat = Console.ReadLine().Trim().ToUpperInvariant();
                        controller.AggiungiMateriaACorso(cod, mat);
                    }
                }
                Console.WriteLine("Corso aggiunto.");
            }
            else
                Console.WriteLine("Errore: codice già esistente.");
        }

        private void AssegnaProfessoreACorso()
        {
            Console.Write("ID Professore: "); string id = Console.ReadLine().Trim().ToUpperInvariant();
            Console.Write("Codice Corso: "); string cod = Console.ReadLine().Trim().ToUpperInvariant();

            if (controller.AssegnaProfessoreACorso(id, cod))
                Console.WriteLine("Professore assegnato.");
            else
                Console.WriteLine("Errore: ID o corso non valido.");
        }

        private void AggiungiStudente()
        {
            Console.Write("Nome: "); string n = Console.ReadLine().Trim();
            Console.Write("Cognome: "); string c = Console.ReadLine().Trim();
            Console.Write("Matricola: "); string m = Console.ReadLine().Trim().ToUpperInvariant();

            Console.WriteLine("Corsi disponibili:");
            foreach (var corso in controller.GetAllCorsi())
                Console.WriteLine($"{corso.Codice}: {corso.Nome}");

            Console.Write("Codice corso: "); string codCorso = Console.ReadLine().Trim().ToUpperInvariant();

            if (controller.AggiungiStudente(n, c, m, codCorso))
                Console.WriteLine("Studente aggiunto.");
            else
                Console.WriteLine("Errore.");
        }

        private void AggiungiVoto()
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine().Trim().ToUpperInvariant();

            var stud = controller.CercaStudente(m);
            if (stud == null)
            {
                Console.WriteLine("Studente non trovato.");
                return;
            }

            Console.WriteLine("Materie disponibili:");
            foreach (var mat in stud.CorsoIscritto.Materie)
                Console.WriteLine($"- {mat}");

            Console.Write("Materia: ");
            string materia = Console.ReadLine().Trim().ToUpperInvariant();

            Console.Write("Voto (0-30): ");
            if (!int.TryParse(Console.ReadLine(), out int voto) || voto < 0 || voto > 30)
            {
                Console.WriteLine("Voto non valido.");
                return;
            }

            if (controller.AggiungiVoto(m, materia, voto))
                Console.WriteLine("Voto aggiunto.");
            else
                Console.WriteLine("Errore: materia non valida per il corso.");
        }


        private void VisualizzaStudenti()
        {
            foreach (var s in controller.GetAllStudenti())
                Console.WriteLine(s);
        }

        private void MediaPiuAlta()
        {
            var s = controller.StudenteMediaPiuAlta();
            Console.WriteLine(s != null ? s.ToString() : "Nessuno studente.");
        }

        private void CercaStudente()
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine().Trim().ToUpperInvariant();
            var stud = controller.CercaStudente(m);

            Console.WriteLine(stud != null ? stud.ToString() : "Non trovato.");
        }

        private void StampaLibretto()
        {
            Console.Write("Matricola: ");
            string m = Console.ReadLine().Trim().ToUpperInvariant();
            Console.WriteLine(controller.StampaLibretto(m));
        }

        private void OrdinaStudenti()
        {
            var lista = controller.OrdinaStudentiPerMedia();
            foreach (var s in lista)
                Console.WriteLine(s);
        }

        private void AggiungiRichiestaCoda()
        {
            Console.Write("Nome: "); string n = Console.ReadLine().Trim();
            Console.Write("Cognome: "); string c = Console.ReadLine().Trim();
            Console.Write("Matricola: "); string m = Console.ReadLine().Trim().ToUpperInvariant();

            Console.WriteLine("Corsi disponibili:");
            foreach (var corso in controller.GetAllCorsi())
                Console.WriteLine($"{corso.Codice}: {corso.Nome}");
            Console.Write("Codice corso: "); string codCorso = Console.ReadLine().Trim().ToUpperInvariant();

            controller.RichiestaNuovoStudente(n, c, m, codCorso);
        }


        private void ApprovaProssimaRichiesta()
        {
            var stud = controller.ApprovaRichiesta();
            if (stud == null)
                Console.WriteLine("Nessuna richiesta in coda.");
            else
                Console.WriteLine($"Richiesta approvata: {stud.Nome} {stud.Cognome}")
           

        }

        private void MostraRichiesteInAttesa()
        {
            var lista = controller.RichiesteInAttesa();
            if (lista.Count == 0)
                Console.WriteLine("Nessuna richiesta in attesa.");
            else
            {
                Console.WriteLine("Richieste in attesa:");
                foreach (var s in lista)
                    Console.WriteLine($"- {s.Nome} {s.Cognome} (Mat: {s.Matricola})");
            }
        }

        private void MostraProssimoInCoda()
        {
            var stud = controller.ProssimoInCoda();
            if (stud == null)
                Console.WriteLine("Nessuno studente in coda.");
            else
                Console.WriteLine($"Prossimo studente in coda: {stud.Nome} {stud.Cognome} (Mat: {stud.Matricola})");
        }

        private void MostraNumeroRichieste()
        {
            Console.WriteLine($"Numero richieste in coda: {controller.NumeroRichieste}");
        }

        private void testGenericRepo()
        {
            controller.TestGenericRepo();
        }

    }
}
