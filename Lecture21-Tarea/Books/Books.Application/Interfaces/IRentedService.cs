using Books.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IRentedService
    {
        Task<IEnumerable<Rented>> GetAllRenteds();
        Task<Rented> GetRentedById(int id);
        Task AddRented(Rented rented);
        Task UpdateRented(Rented rented);
        Task DeleteRented(int id);
    }
}
