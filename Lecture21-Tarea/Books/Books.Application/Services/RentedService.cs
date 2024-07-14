using Books.Application.Interfaces;
using Books.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class RentedService : IRentedService
    {
        private readonly IRepository<Rented> _rentedRepository;

        public RentedService(IRepository<Rented> rentedRepository)
        {
            _rentedRepository = rentedRepository;
        }

        public async Task<IEnumerable<Rented>> GetAllRenteds()
        {
            return await _rentedRepository.GetAll();
        }

        public async Task<Rented> GetRentedById(int id)
        {
            return await _rentedRepository.GetById(id);
        }

        public async Task AddRented(Rented rented)
        {
            await _rentedRepository.Add(rented);
        }

        public async Task UpdateRented(Rented rented)
        {
            await _rentedRepository.Update(rented);
        }

        public async Task DeleteRented(int id)
        {
            await _rentedRepository.Delete(id);
        }
    }

}
