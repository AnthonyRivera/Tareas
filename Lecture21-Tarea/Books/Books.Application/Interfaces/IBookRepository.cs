using Books.Application.Interfaces;
using Books.Domain.Models;

namespace Books.Web.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        /* int Add(Book book);
         void Update(Book book);
         void Delete(int id);
         Book GetById(int id);
         List<Book> GetAll();*/
        Task<List<Book>> GetBookWithRented();
    }
}
