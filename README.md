# LibraryApp

Консольное приложение учёта книг в библиотеке (C#, .NET 8).

## Возможности

- добавление книги в каталог;
- выдача книги с проверкой доступности;
- возврат книги с проверкой, что она была выдана;
- поиск книги по Id;
- вывод каталога.

## Запуск

```
dotnet run --project LibraryApp
```

или открыть `LibraryApp.sln` в Visual Studio и нажать F5.

## Структура

| Класс | Назначение |
|---|---|
| Book | Модель данных книги: Id, Title, Author, IsAvailable |
| Library | Бизнес-логика: AddBook, BorrowBook, ReturnBook, FindBook, ContainsBook |
| Program | Точка входа, интерактивное меню |

## Результаты тестирования

Подробности — в файле [TEST_REPORT.md](TEST_REPORT.md).
