using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    /// <summary>
    /// Библиотека: хранит каталог книг и выполняет операции учёта.
    /// </summary>
    public class Library
    {
        private readonly List<Book> _books = new();

        /// <summary>
        /// Добавляет книгу в фонд.
        /// </summary>
        /// <param name="book">Добавляемая книга.</param>
        /// <exception cref="ArgumentNullException">Книга равна null.</exception>
        /// <exception cref="InvalidOperationException">Книга с таким Id уже существует.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (_books.Any(b => b.Id == book.Id))
                throw new InvalidOperationException($"Книга с Id {book.Id} уже существует");

            _books.Add(book);
        }

        /// <summary>
        /// Выдаёт книгу: проверяет существование и доступность, помечает её выданной.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns>true — если книга выдана.</returns>
        public bool BorrowBook(int id)
        {
            var book = FindBook(id);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена");
                return false;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Книга уже выдана");
                return false;
            }

            book.IsAvailable = false;
            return true;
        }

        /// <summary>
        /// Возвращает книгу: проверяет существование и что книга была выдана.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns>true — если книга возвращена.</returns>
        public bool ReturnBook(int id)
        {
            var book = FindBook(id);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена");
                return false;
            }

            if (book.IsAvailable)
            {
                Console.WriteLine("Книга не была выдана");
                return false;
            }

            book.IsAvailable = true;
            return true;
        }

        /// <summary>
        /// Ищет книгу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns>Найденная книга или null, если книги нет в фонде.</returns>
        public Book FindBook(int id) => _books.FirstOrDefault(b => b.Id == id);

        /// <summary>
        /// Возвращает признак наличия книги в фонде.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns>true — если книга есть в каталоге.</returns>
        public bool ContainsBook(int id) => _books.Any(b => b.Id == id);

        /// <summary>
        /// Возвращает каталог книг для вывода.
        /// </summary>
        /// <returns>Список книг.</returns>
        public IReadOnlyList<Book> GetAllBooks() => _books;
    }
}
