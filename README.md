# BlazorServerBotVision

**BlazorServerBotVision** ist eine Blazor Server Anwendung, die auf den Prinzipien der Clean Architecture basiert. Die App ermöglicht es Anwendern, mit einem AI Chatbot zu interagieren und dabei zusätzlich Daten aus einer MS SQL Database (via EF Core) zu nutzen. Die Antworten der AI sowie die aus der Datenbank gewonnenen Informationen werden getrennt angezeigt, sodass der Anwender beide Ergebnisse klar unterscheiden kann.

## Key Features

- **Clean Architecture:** Klare Trennung von Domain, Application, Persistence, Infrastructure, Presentation, Shared und UI zur besseren Wartbarkeit und Skalierbarkeit.
- **Blazor Server:** Moderne, komponentenbasierte Benutzeroberfläche mit C# und Blazor.
- **EF Core & MS SQL Server:** Robuste Datenpersistenz, migrationsbasiert und asynchron implementiert.
- **Statische DI-Konfiguration:** Konfiguration der Abhängigkeiten über statische, erweiterte Methoden anstelle der üblichen DI im `Program.cs`.
- **AI Integration:** Nutzung eines AI Dienstes (OpenAI) für Chatbot Funktionalitäten.
- **Asynchrone Programmierung:** Effiziente Datenverarbeitung.
- **Logging, Caching & Sessions:** Integriertes Logging für Diagnostik, geplante Caching Mechanismen und Session Management.
- **Unit Testing:** Gut strukturierte Grundlage für umfangreiche Unit Tests.
- **Authentication/Authorization:** Wurde mit dem vierten Meilenstein integriert.

## Projektstruktur
- **Domain:**   
- **Application:** 
- **Persistence:** 
- **Infrastructure:**
- **Presentation:** 
- **Shared:** 
- **UI:**
- 
## Voraussetzungen

- Visual Studio 2022
- .NET9 SDK
- MS SQL Server
- Nuget Pakete - z.B.: Blazored.SessionStorage, OpenAI,
- OpenAI Key
- ConnectionString


## umgesetzte Meilensteine

**Meilenstein v1.0 – Clean Architecture**

Fokus: Aufbau der gesamten Architektur
Bereiche: Domain, Application, Infrastructure, Presentation, Persistence, Presention, UI

**Meilenstein v2.0 – AI Integration**

Fokus: Integration von OpenAI
Ziel: Intelligente AI Features in die Anwendung einbinden

**Meilenstein v3.0 – UI Integration**

Fokus: Verbindung der Benutzeroberfläche mit der Backend Logik

**Meilenstein v4.0 – User Login, Autorisierung, Authentifizierung und SessionStorage**

Fokus: Login und Registrierung, Sicherheitsfunktionen (Autorisierung und Authentifizierung) sowie Session Verwaltung
