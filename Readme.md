## Informacje podstawowe
Celem niniejszej aplikacji było zapoznanie się z techniką tworzenia API sieciowego w środowisku .NET, z zastosowaniem podstawowego uwierzytelniania użytkowników.

## Obsługa aplikacji

1. Wygenerowanie tokenu

Należy wysłać zapytanie HTTP POST pod adres /connect/token, w postaci x-www-form-urlencoded, z parametrem grant_type: password, a także parametrami username i password, przyjmującymi za wartości login i hasło użytkownika.

2. Dostęp do zabezpieczonych punktów dostępowych

W nagłówku zapytania musimy podać parametr Authorization, który przyjmuje wartość: Bearer <access_token>. Token pobieramy oczywiście w sposób podany w punkcie 1.

## Wykorzystane technologie:
- język programowania C#
- środowisko .NET Core 2.0
- biblioteka OpenIddict (https://github.com/openiddict/openiddict-core)

NIE używałem frameworku ASP.NET Core Identity, ponieważ klasa IdentityUser ma zbyt dużo niepotrzebnych pól, które zaśmiecałyby bazę danych.

## Wymagania techniczne

Aplikacja działa w środowisku .NET Core w wersji 2.0. SDK niezbędne do uruchomienia aplikacji można pobrać pod adresem: https://www.microsoft.com/net/download

## Przygotowanie aplikacji do działania

Informacje o użytkownikach zapisane są w bazie danych - MS SQL Server. Zapis hasła w bazie jest szyfrowany przy pomocy SHA-256.

1. Generowanie szkieletu bazy danych

Aby wygenerować bazę danych, musimy najpierw przygotować parametry łączenia z bazą w Twoim komputerze. Odpowiada za to parametr ConnectionStrings.DefaultConnection umieszczony w pliku appsettings.json.

Następnym etapem jest wygenerowanie migracji oraz zapisanie szkieletu bazy danych.
W tym celu, proszę wpisać do konsoli następujące polecenia:

dotnet ef migrations add Initial

gdzie słowo Initial jest nazwą migracji i może zostać dowolnie zmienione.
Następnie proszę wpisać:

dotnet ef database update

2. Przygotowanie użytkowników systemu.

a) Tworzenie użytkowników

W tym celu proszę - dla każdego użytkownika - wykonać w bazie następujące zapytanie SQL.

INSERT INTO Users VALUES ('<user_id>', '<user_email>', '<hashed_password>', '<user_name>');

Wartością parametru "user_id" powinien być ciąg znaków - tzw. GUID / UUID. Można go wygenerować np. na stronie:

https://www.guidgenerator.com/online-guid-generator.aspx

Wartością parametru "hashed_password" jest hasło PO ZASZYFROWANIU metodą SHA-256. Przykładowy generator online:

http://passwordsgenerator.net/sha256-hash-generator/

Parametry "user_email" oraz "user_name" ustawiamy według własnego życzenia.

b) Role użytkowników

Użytkownik może występować jako "user", "admin", lub mieć jednocześnie obie te role.

Musimy najpierw umieścić je w bazie danych:
INSERT INTO Roles VALUES('225baeb0-bed5-4a03-987d-082a272bd32f', 'User');
INSERT INTO Roles VALUES('85ec8be5-8108-44ed-b363f3df765db495', 'Admin');

c) Przydzielanie ról użytkownikom

Odpowiada za to tabela łącząca UserRoleJoin.

INSERT INTO UserRoleJoin VALUES('<join_id>', '<role_id>', '<user_id>');

Wartości parametrów "role_id" oraz "user_id" muszą być identyczne co identyfikatory odpowiednio roli i użytkownika, któremu chcemy daną rolę nadać.

Z kolei w miejscu "join_id" wpisujemy dowolny GUID (UUID). Istnienie tego identyfikatora jest pewnego rodzaju usterką systemu. Prawidłowym jego działaniem byłoby, gdyby identyfikatorem tabeli była kombinacja wartości "role_id" i "user_id". Poprawię to, jeśli znajdę czas.

## Uruchamianie aplikacji

Proszę wpisać do konsoli:

dotnet run

Można też skorzystać z IDE, np. JetBrains Rider czy MS Visual Studio.