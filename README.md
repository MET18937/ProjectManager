# Projekt-Manager

Der Projektmanager soll den Schülern das letzte Jahr für ihr Abschlussprojekt erleichtern.
Sie können diese Plattform nutzen, um sich von bereits realisierten Projektideen inspirieren zu lassen. Sie können auch Kontakt mit einem Betreuer aufnehmen, um ein Projekt zu starten. Unternehmen und Lehrer können Schulprojekte anbieten.

Hauptziel ist es, den Schülern mehr Anerkennung zu verschaffen, damit ihre Abschlussprojekte nicht in der Bibliothek verstauben, sondern in der digitalen Welt genutzt werden und zukünftigen Absolventen helfen können.

## Datenbank

1. Project
2. Supervisor
3. Teacher
4. Company
5. Student
6. StudenthasProject

### Grafische Dartellung


![DBModell](./DBModell.png)

### Migration
Im Nuget Manager Console folgende Befehle ausführen:
```
Add-Migration InitialCreate
Update-Database
```


