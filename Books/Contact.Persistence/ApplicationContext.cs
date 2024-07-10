using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Books.Domain.Models;

namespace Books.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
    }

}
