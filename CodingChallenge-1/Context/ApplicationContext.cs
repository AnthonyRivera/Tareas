
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodingChallenge_1.Models;

namespace CodingChallenge_1.Context{
    public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    public DbSet<Book> Book { get; set; }
    public DbSet<Book> Author { get; set; }
}

}