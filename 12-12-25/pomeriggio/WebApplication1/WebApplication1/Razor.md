# ?? 1) COSA È UNA RAZOR VIEW?

È un file con estensione **.cshtml** che contiene:

* HTML normale
* C# mescolato all’HTML
* direttive speciali Razor (iniziano con `@`)

Esempio:
---
@model Studente

<h1>Ciao @Model.Nome</h1>

---
Qui:
* HTML è `<h1> ... </h1>`
* C# è `@Model.Nome`


# ?? 2) IL SIMBOLO "@" È IL CUORE DI RAZOR

Significa: **"da qui in poi sto scrivendo C#"**.

Esempi:

```html

<p>Oggi è: @DateTime.Now</p>

```

```html

@foreach (var s in Model) {
    <p>@s.Nome</p>
}

```

```html

@{
    var x = 10;
    var y = x * 2;
}
<p>@y</p>

```

---

# ?? 3) DIRETTIVE RAZOR PIÙ IMPORTANTI

### `@model`

Indica il tipo di oggetto che la view riceve dal controller.

```csharp

@model IEnumerable<Studente>

```

Dopo questa riga, puoi usare:

```csharp

Model     ? l'oggetto della view
@Model.Id ? proprietà

```

---

### `@{ ... }`

Blocco di C# standalone dentro HTML.

```html
@{
    int totale = 5 + 3;
}
<p>Totale: @totale</p>
```

---

### `@if`, `@foreach`, `@for`

Normale sintassi C#:

```html
@if(Model.Eta >= 18)
{
    <p>Maggiorenne</p>
}
else
{
    <p>Minorenne</p>
}
```

```html
@foreach (var s in Model)
{
    <p>@s.Nome @s.Cognome</p>
}
```

---

# ?? 4) IL MODEL BINDING NELLA VIEW (TAG HELPERS)

ASP.NET aggiunge i **Tag Helper**.
Esempi:

```html
<input asp-for="Nome" class="form-control" />
<label asp-for="Nome"></label>

<a asp-action="Edit" asp-route-id="@s.Id">Modifica</a>
```

I tag helper:

* costruiscono la URL automaticamente
* sanno qual è il controller corrente
* seguono il routing
* costruiscono nome dei campi per form binding

Sono indispensabili.

---

# ?? 5) ESEMPIO COMPLETO DI RAZOR PAGE (CRUD)

```html
@model Studente

<h2>Modifica Studente</h2>

<form asp-action="Edit" method="post">
    <input type="hidden" asp-for="Id" />

    <div class="mb-3">
        <label asp-for="Nome" class="form-label"></label>
        <input asp-for="Nome" class="form-control" />
    </div>

    <div class="mb-3">
        <label asp-for="Cognome" class="form-label"></label>
        <input asp-for="Cognome" class="form-control" />
    </div>

    <div class="mb-3">
        <label asp-for="Eta" class="form-label"></label>
        <input asp-for="Eta" class="form-control" />
    </div>

    <button type="submit" class="btn btn-warning">Aggiorna</button>
</form>

<a asp-action="Index">Torna alla lista</a>
```

Cosa contiene?

* `@model Studente`
* HTML del form
* Tag helper per costruire input e link
* binding automatico tra form ? metodo POST del controller

---

# ?? 6) COME FUNZIONA IL BINDING

Il controller manda un modello:

```csharp
return View(studente);
```

La view riceve:

```csharp
@model Studente
```

Quando il form fa POST, ASP.NET ricostruisce un **nuovo Studente** con i valori degli input:

```html
<input asp-for="Nome" />
```

diventa:

```
Nome = "Mario"
```

nel parametro dell’azione POST:

```csharp

public IActionResult Edit(Studente s)

```

Semplice e automatico.

---

# ?? 7) FORM POST ? ACTION

Il form è:

```html
<form asp-action="Edit" method="post">
```

quindi chiama:

```
POST /Studente/Edit
```

Che viene mappato alla funzione:

```csharp
[HttpPost]
public IActionResult Edit(Studente s)
```

---

# ?? 8) DIFFERENZA TRA RAZOR E RAZOR PAGES

Noi stiamo usando **Views MVC**, non **Razor Pages**.
Sono due cose diverse:

| Views MVC                              | Razor Pages                              |
| -------------------------------------- | ---------------------------------------- |
| Controller + View                      | Nessun controller                        |
| Pattern MVC classico                   | Pattern PageModel                        |
| gestisci la view in StudenteController | gestisci la logica in Studente.cshtml.cs |


---

# ?? 9) SPIEGAZIONE FINALE

> «Una Razor View è una pagina HTML che può includere codice C# usando il simbolo @.
> La pagina riceve un Model dal controller, usa i tag helper per costruire automaticamente 
> gli input e usa il Model Binding per trasformare i valori del form in un oggetto C# da passare al controller.»

---

