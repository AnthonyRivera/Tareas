using Lecture19_Tarea.Models;

namespace Lecture19_Tarea.Interfaces
{
    public interface IBookRepository
    {
        int Add(Book book);
        void Update(Book book);
        void Delete(int id);
        Book GetById(int id);
        List<Book> GetAll();
    }
}
