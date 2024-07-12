using Books.Api.Dtos.Books;
using Books.Domain.Models;

namespace Books.Api.Helpers
{
    public class BookHelper
    {
        public static BookDto ToBookDto(Book book)
        {
            return new BookDto
            {
                BookId=book.BookId,
                BookName = book.BookName,
                Author = book.Author,
                ReleaseYear = book.ReleaseYear
            };
        }
        public static Book ToBook(BookDto dto)
        {
            return new Book
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                Author = dto.Author,
                ReleaseYear = dto.ReleaseYear
            };
        }
        public static Book ToBook(CreateBookDto dto)
        {
            return new Book
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                Author = dto.Author,
                ReleaseYear = dto.ReleaseYear
            };
        }
    }
}
