using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Lecture19_Tarea.Models;

namespace Lecture19_Tarea.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
    }

}
