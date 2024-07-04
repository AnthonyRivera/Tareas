using CodingChallenge_1.Context;
using CodingChallenge_1.Interfaces;
using CodingChallenge_1.Models;
using CodeChallenge_1.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var options = new DbContextOptionsBuilder<ApplicationContext>()
    .UseSqlServer(ConfigurationManager.ConnectionStrings["BibliotecaDbCnn"].ConnectionString)
    .Options;

var context = new ApplicationContext(options);

IBookRepository bookRepository = new BookAdoRepository();
IAuthorRepository authorRepository=new AuthorAdoRepository();
var newBook = new Book
{
    BookName = "Sanson",
    Author = "Charando",
    ReleaseYear = "2009-06-06",
};


int newId = bookRepository.Add(newBook);
var book = bookRepository.GetById(newId);
Console.WriteLine($"Book retrieved: {book.BookName},{book.Author},{book.ReleaseYear},{book.BookId}");
newBook.BookId= newId;
newBook.Author = "Parpyruspus";
Console.WriteLine($"{newBook.Author} {newBook.BookId} and {newId}");
bookRepository.Update(newBook);
var updatedBook = bookRepository.GetById(newId);
Console.WriteLine($"Book updated: {updatedBook.BookName},{updatedBook.Author},{updatedBook.ReleaseYear}");
bookRepository.Delete(newId);
Console.WriteLine("Book deleted.");
var books = bookRepository.GetAll();
foreach (var c in books)
{
    Console.WriteLine($"{c.BookName} {c.Author} {c.ReleaseYear}");
}
Console.WriteLine("");
var newAuthor = new Author
{
    Name = "Yo",
    LastName = "mi apellido"
};
int nuevoId = authorRepository.Add(newAuthor);
var author = authorRepository.GetById(nuevoId);
Console.WriteLine($"Author retrieved: {author.Name},{author.LastName},{author.AuthorId}");
newAuthor.AuthorId = nuevoId;
newAuthor.Name = "Anthony";
Console.WriteLine($"{newAuthor.Name} {newAuthor.AuthorId} and {nuevoId}");
authorRepository.Update(newAuthor);
var updatedAuthor = authorRepository.GetById(nuevoId);
Console.WriteLine($"Author updated: {updatedAuthor.Name},{updatedAuthor.LastName},{updatedAuthor.AuthorId}");
authorRepository.Delete(nuevoId);
Console.WriteLine("Author deleted.");
var authors = authorRepository.GetAll();
foreach (var c in authors)
{
    Console.WriteLine($"{c.Name} {c.LastName}");
}
Console.WriteLine("");