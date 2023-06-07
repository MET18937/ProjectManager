# Anforderungen Projekt POS SS 22/23

## Midenstanforderungen f�r ein Gen�gend (4):

### DB:
* Simpel, aber mind. 5 Tabellen inkl. Lookup-Tables

### Entities:
* Entities
  - [x] sichere Listen
  - [ ] Konstruktoren
  - [x] Relations / Navigations
  - [x] Teileweise Logik (TDD) (Produkt in den Warenkorb legen, pr�ft: Produkt-St�ckzahl, ob Produkt schon im Warenkorb ist , dekrementiert Produkt-St�ckzahl, ...)
  - [ ] Unite Tests (TDD)
    - [ ] Create_Success_Test (Eine Entity adden)
    - [ ] Relations / Navigations
- [ ] Enums
- [ ] Lookup-Tables
- [ ] Value Objects

### Service:
* mind. 2 Services
* Get-Methode(n) min. eine Methode, zur Auflistung der Daten aus einer Tabelle
* Create/Update/Delete-Methoden
  * Create: mind. 5 Bedingungen (LinQ) pr�fen (Bedingungen sollen pr�fen, ob ein Datensatz angelegt werden darf)
  * Update: mind. 2 Bedingungen (LinQ) pr�fen (Bedingungen sollen pr�fen, ob ein Datensatz ge�ndert werden darf)
* Filtering / Sorting / Paging implementieren
* C.R.U.D. + Fluent-API oder Mediator + C.Q.S. oder etwas anderes

### Unit Tests:
* Domain Model: pro Entity mind. 1 Success_Test
* Services: Alle Create/Update/Delete-Method Test Driven (TDD) implementieren (100%ige Code-Abdeckung), ohne Mocking

### Repository:
* generisches Repo, und/oder spezialisierte Repos

### Controller:
* mind. 2
* Alle Service Methoden auch in (mehreren) Controllern abbilden

### UI:
(coming soon)

### GIT:
Abgabe auf GIT + Pr�sentation. M�glichst viele pushes �ber den Zeitraum verteilt

---

## Implementierungsvorschl�ge f�r 3 bis 1:

* Sauberes und durchg�ngiges Exception Handling
* Ein simpler, rudiment�rer LogIn/LogOut
* Filterung nach einem Freitextfeld, einem Datumsraum UND einer Drop-Down-Box. Jedes davon optional
* Volltextsuche mit Fehlerkorrektur in einer Tabelle, z.B. Namen
* Erh�hung der Anzahl der Pr�fungen in den Service-Methoden (Add/Update/Delete)
* DTO Mapping
* Ein Service benutzt einen anderen Service zur Datenvalidierung (z.B. StockService pr�ft Lagerbest�nde)
* �ber die Angabe hinaus, eine weiterer Service mit Add- Update- Delete-Methode
* Umsetzung mittels C.Q.R.S. und MediatR (C.Q.R.S.- und Mediator-Pattern)
* Mocking: MoQ wird f�r TDD verwendet
* GIT: Arbeiten mit Feature-Branches, idealerweise 1 Branch pro Feature + Merge auf den Main-Branch

Ein Punktespiegel f�r ene Note besser als 4, +/- ein Notengrad. Code Quality (Optik und Sauberkeit) spielt ebenfalls eine Rolle, ist aber schwer monet�r messbar.

## Bewertungskriterien:

* Domain Model inkl. Infrastructure (siehe Anforderungen oben)
* Domain Model Tests
  * Codeabdeckung
* Repositories (siehe Anforderungen oben)
* Repositories Tests
  * TDD Codeabdeckung
* Application (siehe Anforderungen oben)
* Application Tests
  * TDD Codeabdeckung
* Presentation (siehe Anforderungen oben)
* Presentation Tests
  * Integration Tests, idealerweise TDD, Codeabdeckung
* Git-Performance
  * H�ufigkeit und Abstand der einzelnen Pushes
  * Anzahl der Branches
  * Verwendung von Merge, Rebase, Squash, ...
* Code Cquality:
  * Keine auskommentierten Codeteile
  * Einhaltung der Coding Conventions
  * Einr�ckungen, unn�tige Leerzeilen, ...
  * *How smells your code*


| Note | Punkteanzahl |
|---|---|
| 3 | > 3 |
| 2 | > 6 |
| 1 | > 9 |
