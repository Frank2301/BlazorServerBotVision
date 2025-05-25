# BlazorServerBotVision

**BlazorServerBotVision** ist eine Blazor Server Anwendung, die auf den Prinzipien der Clean Architecture basiert. Die App ermöglicht es Anwendern, mit einem AI Chatbot zu interagieren und dabei zusätzlich Daten aus einer MS SQL Database (via EF Core) zu nutzen. Die Antworten der AI sowie die aus der Datenbank gewonnenen Informationen werden getrennt angezeigt, sodass der Anwender beide Ergebnisse klar unterscheiden kann.

## Key Features

- **Clean Architecture:** Klare Trennung von Domain, Application, Persistence, Infrastructure, Presentation, Shared und UI zur besseren Wartbarkeit und Skalierbarkeit.
- **Blazor Server:** Moderne, komponentenbasierte Benutzeroberfläche mit C# und Blazor.
- **EF Core & MS SQL Server:** Robuste Datenpersistenz, migrationsbasiert und asynchron implementiert.
- **Statische DI-Konfiguration:** Konfiguration der Abhängigkeiten über statische, erweiterte Methoden anstelle der üblichen DI im `Program.cs`.
- **AI Integration:** Nutzung von AI Diensten (Azure.AI.OpenAI bzw. Microsoft.Extensions.AI) für Chatbot-Funktionalitäten.
- **Asynchrone Programmierung:** Effiziente und responsive Datenverarbeitung.
- **Logging, Caching & Sessions:** Integriertes Logging für Diagnostik, geplante Caching Mechanismen und Session Management.
- **Unit Testing:** Gut strukturierte Grundlage für umfangreiche Unit Tests.
- **Zukünftige Features:** Erweiterung um Authentication/Authorization.

## Projektstruktur

- **Domain:** Enthält Kern-Entitäten (z. B. User, Chat, ChatHistory) und Schnittstellen (z. B. IUserRepository).
- **Application:** Implementiert die Geschäftslogik (Services) und enthält dazugehörige DTOs.
- **Persistence:** Beinhaltet `ApplicationDbContext`, EF Core Migrations, Repository Implementierungen und Konfigurationen.
- **Infrastructure:** Kapselt externe Service Integrationen sowie Logging und hilfreiche Utilities.
- **Presentation:** Verantwortlich für Anwendungsstart, Routing und DI Konfiguration mittels statischer Erweiterungsmethoden.
- **Shared:** Bietet Basis Klassen, Utilities und Konfigurationen, die in mehreren Projekten wiederverwendet werden.
- **UI:** Implementiert Blazor-Komponenten und Seiten für die Benutzeroberfläche.

## Voraussetzungen

- Visual Studio 2022
- .NET9 SDK
- MS SQL Server
- Die in der `architecture.md` dokumentierten NuGet Pakete

## Einrichtung und Ausführung

1. Repository klonen.
2. NuGet Pakete wiederherstellen.
3. EF Core Migrationen ausführen, um die Datenbank zu initialisieren.
4. In Visual Studio 2022 starten.

## Meilensteine

Der erste Meilenstein **"Meilenstein v1.0 - Clean Architecture"** fokussiert sich auf den Aufbau der gesamten Architektur inklusive Domain, Application und Persistence. Zukünftige Meilensteine werden weitere Funktionen wie AI-Integration, Caching, Logging und Authentifizierung umfassen.
