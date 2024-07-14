using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Books.Domain.Models;
using Books.Domain;

namespace Books.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Book> Book { get; set; }
        public DbSet<Rented> Rented { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasMany(b => b.Renteds)
            .WithOne(a => a.Book)
            .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book>().Property(p => p.BookName).IsRequired();

            modelBuilder.Entity<Rented>()
            .HasOne(b => b.Book)
            .WithMany(a => a.Renteds)
            .HasForeignKey(b => b.BookId);


            base.OnModelCreating(modelBuilder);
        }
    }

}
