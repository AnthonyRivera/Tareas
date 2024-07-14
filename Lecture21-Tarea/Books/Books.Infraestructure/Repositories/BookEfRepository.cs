using Books.Application.Interfaces;
using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infraestructure.Repositories
{
    public class BookEfRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookEfRepository(ApplicationContext context) :base(context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBookWithRented()
        {
            return await _context.Book.Include(c=>c.Renteds).ToListAsync();
        }
    }
}
