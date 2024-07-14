using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
