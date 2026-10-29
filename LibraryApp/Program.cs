using System;
using System.Globalization;

namespace LibraryApp
{
    /// <summary>
    /// Точка входа: интерактивное меню библиотеки.
    /// </summary>
    public static class Program
    {
        private static readonly Library Library = new();

        /// <summary>Точка входа приложения.</summary>
        public static void Main()
        {
            char choice;

            do
            {
                Console.Clear();
                PrintMenu();
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        AddBook();
                        break;
                    case '2':
                        BorrowBook();
                        break;
                    case '3':
                        ReturnBook();
                        break;
                    case '4':
                        FindBook();
                        break;
                    case '5':
                        PrintCatalog();
                        break;
                }

                if (choice != '0')
                {
                    Console.WriteLine();
                    Console.Write("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            } while (choice != '0');
        }

        private static void PrintMenu()
        {
            Console.WriteLine("===== Библиотека =====");
            Console.WriteLine("1 - Добавить книгу");
            Console.WriteLine("2 - Выдать книгу");
            Console.WriteLine("3 - Вернуть книгу");
            Console.WriteLine("4 - Найти книгу");
            Console.WriteLine("5 - Показать каталог");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите пункт меню: ");
        }

        private static void AddBook()
        {
            Console.Write("Введите Id книги: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный Id");
                return;
            }

            Console.Write("Введите название: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора: ");
            string author = Console.ReadLine();

            try
            {
                Library.AddBook(new Book(id, title, author));
                Console.WriteLine("Книга добавлена");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Ошибка: данные книги не заполнены");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void BorrowBook()
        {
            Console.Write("Введите Id книги для выдачи: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный Id");
                return;
            }

            if (Library.BorrowBook(id))
                Console.WriteLine("Книга выдана");
        }

        private static void ReturnBook()
        {
            Console.Write("Введите Id книги для возврата: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный Id");
                return;
            }

            if (Library.ReturnBook(id))
                Console.WriteLine("Книга возвращена");
        }

        private static void FindBook()
        {
            Console.Write("Введите Id книги для поиска: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный Id");
                return;
            }

            var book = Library.FindBook(id);
            if (book == null)
                Console.WriteLine("Книга не найдена");
            else
                PrintBook(book);
        }

        /// <summary>Вывод каталога — вынесен из Main по принципу «один метод — одна задача».</summary>
        private static void PrintCatalog()
        {
            var books = Library.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("Каталог пуст");
                return;
            }

            Console.WriteLine("===== Каталог книг =====");
            foreach (var book in books)
                PrintBook(book);
        }

        private static void PrintBook(Book book)
        {
            string status = book.IsAvailable ? "доступна" : "выдана";
            Console.WriteLine(
                string.Format(CultureInfo.InvariantCulture,
                    "Id: {0} | {1} | {2} | {3}",
                    book.Id, book.Title, book.Author, status));
        }
    }
}
