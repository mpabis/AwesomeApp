# Awesome App

Aplikacia sluzi ako demo s pouzitim Clean architektury, backend .NET Core 5.0, frontend ASP.NET Core a desktopova aplikacia pomocou Electron.NET.

Aplikacia implementuje nakupny zoznam.

## Core

Je centrom aplikacie s Clean architekturou, obsahuje triedy:

- entity
- agregacie
- domenove udalosti
- DTO triedy
- interface
- handlery udalosti
- specifikacie

Obsahuje domenove triedy a business logiku aplikacie. Core ma velmi malo externych zavislosti, vsetky ostatne komponenty zavisia na Core.

![Clean Architektura](AwesomeAppClean.svg)


## Infrastructure

Obsahuje manazment externych zdrojov ako su databazy, suborovy system, externe servisy (API). Pouziva Entity Framework Core na pristup k databazam.

## SharedKernel

Pouziva sa ako oddeleny projekt s kodom zdielanym medzi roznymi bounded kontextmi (DDD metodologia). Obsahuje zakladne base triedy pre domenovu udalost, ValueObject a interface IRepository a IAggregateRoot.

## Web

Implementuje API endpointy ako aj weboveho klienta pomocou ASP.NET Core.

# Tests

Pouziva xunit, Moq a TestHost.