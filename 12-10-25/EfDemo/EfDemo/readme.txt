APPUNTI & TO DO:

// - Creare un progetto EF Core con Code First
// - Creare una classe DbContext
// - Creare delle classi POCO (Plain Old CLR Object) per rappresentare le entità del database
// - Configurare la connessione al database nel DbContext
// - Utilizzare le migrazioni per creare e aggiornare il database
// - Eseguire operazioni CRUD (Create, Read, Update, Delete) utilizzando il DbContext
// - Esempi di query LINQ per recuperare dati dal database
// - Gestire le relazioni tra entità (uno a molti, molti a molti, ecc.)

// - Pattern MVC da rispettare nella struttura del progetto mettendo db context in Data
// - NON DARE DIEPNDENZE ALLA MIANVIEW DEL CONTROLLER!
// - Implementare tabella cross per entità molti a molti (es. studenti-corsi)

in View 
- ci deve essere semplicità quidni suddivbidendo in più view, creando dei menù principale che scendono in sotto menu ad esempio:
scegli 1 per gesitone studenti, 2 per gestione docenti ,3 per gestione corsi e ogni funzione chiama un altra classe e relativo metodo.
- creare oggetti nella view che passiamo al controller senza passare attributi singoli.
-

In Controller chiasmare direttamente em,todi linq di db context.

Entità da implementare:

Corsi

a studente aggiungere eta matricola e id corso(che verrà trasformato in seguito)


poi fare controlli su inserimento se inserisce o meno ecc, am prima focus sulle funzionalità base.

____README PROF:____
# Flusso No Repository
Program --> MenuView.Show()
--> studView.Menu()
--> Create()
--> Studente.controller.Create(nome, cognome)
- db.Studenti.Add(studente)
- db.SaveChanges

** Il controller conosce troppi dettagli del database.

# QUALI MODIFICHE DOVREMMO FARE?

** aggiungere campi
se in modello esistente (esempio Studente.Eta)
PM> Add-Migration AggiungiEta
Update-Database

# Creare una migration
Add-Migration NomeMigration

# Applicare le migration al database
Update-Database

# Tornare a una migration prece#dente
Update-Database NomeMigration

# Eliminare l’ultima migration (solo file, non DB)
Remove-Migration

# drop tabelle database EF
Drop-Database
Add-Migration Iniziale

# aggiungere campi
se in modello esistente (esempio Studente.Eta)
PM> Add-Migration AggiungiEta
Update-Database

# aggiungere modelli
se in modello esistente (esempio Studente.Eta)
PM> Add-Migration AggiungiEta
Update-Database




