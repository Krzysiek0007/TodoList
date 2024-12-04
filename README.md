![](./media/solutions-microsoft-logo-small.png)

# Aplikacja "Todo List"
Aplikacja umożliwia użytkownikowi planowanie zadań.

## Główne cechy programu

- aplikacja typu web ASP.NET CORE 9.0
- aplikacja wykorzystuje bazę danych MSSQL i korzysta z Microsoft.AspNetCore.Identity.EntityFrameworkCore 9.0
- aplikacja zawiera dwa podstawowe widoki: lista zadań i kalendarz
- funkcjonalność aplikacji obejmuje:
    - dodawanie/usuwanie/edycję zadań dla określonego dnia
    - zmianę dnia dla którego wyświetlane są zadania, a ponadto oferuje inne rozszerzone możliwości w widoku kalendarza,
    - powiadomienia (co 10 sek.) o zbliżających się zadaniach, do których rozpoczęcia pozostało mniej niż 30 minut.
- dodatkowo:
    - po kliknięciu powiadomienia przechodzi się do okna szczegółów zadania,
    - gdy kursor myszy znajdzie się na powiadomieniu, to nie zniknie ono od razu,
    - w kalendarzu po kliknięciu zadania wyświetla się okno szczegółów.

## Adres strony
http://

## Kod źródłowy
https://github.com/Krzysiek0007/TodoList.git