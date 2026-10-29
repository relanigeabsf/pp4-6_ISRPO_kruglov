using System;

namespace LibraryApp
{
    /// <summary>
    /// Модель данных книги.
    /// </summary>
    public class Book
    {
        /// <summary>Уникальный идентификатор книги.</summary>
        public int Id { get; }

        /// <summary>Название книги.</summary>
        public string Title { get; }

        /// <summary>Автор книги.</summary>
        public string Author { get; }

        /// <summary>Признак доступности книги в фонде.</summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Создаёт экземпляр книги. По умолчанию книга доступна.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="title">Название книги.</param>
        /// <param name="author">Автор книги.</param>
        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }
}
