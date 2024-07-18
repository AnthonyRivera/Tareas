using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Books.Domain.Models;
using Books.Domain;

namespace Books.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Paciente> Pacientes { get; set; }
       

     
    }

}
