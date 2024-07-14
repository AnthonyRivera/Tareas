using Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
        Task<List<Book>> GetBookWithRented();
    }
}
