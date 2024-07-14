using Books.Application.Interfaces;
using Books.Domain.Models;
using Books.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository=bookRepository;
        }
        public async Task AddBook(Book book)
        {
            await _bookRepository.Add(book);
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepository.Delete(id);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<List<Book>> GetBookWithRented()
        {
            return await _bookRepository.GetBookWithRented();
        }

        public async Task UpdateBook(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
