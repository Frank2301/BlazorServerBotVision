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
- **Domain:**  
    Beinhaltet Kern-Entitäten wie `User` (mit Basisinformationen und geerbtem `BaseEntity`), `Chat` und `ChatHistory`. Alle Entitäten nutzen GUIDs als Primärschlüssel,      um eine weltweit eindeutige Identifikation sicherzustellen.
- **Application:** Implementiert die Geschäftslogik (Services) und enthält dazugehörige DTOs.
- **Persistence:**  
    Beinhaltet den `ApplicationDbContext`, EF Core Migrations sowie ausgelagerte Konfigurationsklassen (z. B. `UserConfiguration`, `ChatConfiguration`, ChatHistoryConfiguration`), die das Datenbankschema anhand der Domain Modelle definieren.
- **Infrastructure:** Kapselt externe Service Integrationen sowie Logging und hilfreiche Utilities.
- **Presentation:** Verantwortlich für Anwendungsstart, Routing und DI Konfiguration mittels statischer Erweiterungsmethoden.
- **Shared:** Bietet Basis Klassen, Utilities und Konfigurationen, die in mehreren Projekten wiederverwendet werden.
- **UI:** Implementiert Blazor-Komponenten und Seiten für die Benutzeroberfläche.

## Voraussetzungen

- Visual Studio 2022
- .NET9 SDK
- MS SQL Server

## Einrichtung und Ausführung

1. Repository klonen.
2. NuGet Pakete wiederherstellen.
3. EF Core Migrationen ausführen, um die Datenbank zu initialisieren.
4. In Visual Studio 2022 starten.

## Meilensteine

Der erste Meilenstein **"Meilenstein v1.0 - Clean Architecture"** fokussiert sich auf den Aufbau der gesamten Architektur inklusive Domain, Application und Persistence. Der zweite Meilenstein **"Meilenstein v2.0 - AI Integration"** auf die Integratrion von OpenAI. Zukünftige Meilensteine werden weitere Funktionen, wie z.B. Caching, Logging und Authentifizierung umfassen.
