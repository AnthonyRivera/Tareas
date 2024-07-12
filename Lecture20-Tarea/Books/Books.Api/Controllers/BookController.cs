using Books.Api.Dtos.Books;
using Books.Api.Helpers;
using Books.Api.Responses;
using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Books.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController:ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationContext _context;
        private readonly BookAdoRepository _bookAdoRepository;


        public BookController(IBookRepository bookRepository, ApplicationContext context, BookAdoRepository bookAdoRepository)
        {
            _bookRepository = bookRepository;
            _context= context;
            _bookAdoRepository = bookAdoRepository;


        }

        [HttpGet(Name = "GetBooks")]
        public BookResponse Get()
        {
            var response = new BookResponse();
            response.Message = "Todo Bien";
            var booksFromDb = _bookRepository.GetAll();
            var booksToReturn = new List< BookDto > ();
            foreach (var book in booksFromDb)
            {
                /*booksToReturn.Add(new BookDto
                {
                    BookName = book.BookName,
                    Author = book.Author,
                    ReleaseYear = book.ReleaseYear
                });*/
                booksToReturn.Add(BookHelper.ToBookDto(book));
            }
            response.Books = booksToReturn;
            return response;
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> Get(int id)
        {
            var booksFromDb = _context.Book.FirstOrDefault(p => p.BookId == id);
            if (booksFromDb == null)
            {
                return NotFound("Book not found");
            }
            return Ok(booksFromDb);
        }

        [HttpPost(Name = "CreateBook")]
        public async Task<IActionResult> Create([FromBody] CreateBookDto model)
        {
            if (model == null)
            {
                return BadRequest("Book data is null");
            }

            if (ModelState.IsValid)
            {
                /*var bookDb = new Book
                {
                    BookName = model.BookName,
                    Author=model.Author,
                    ReleaseYear =model.ReleaseYear

                };*/
                var bookDb = BookHelper.ToBook(model);
                        
                _context.Book.Add(bookDb);
                model.BookId = bookDb.BookId;
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetBook", new { id = bookDb.BookId }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public async Task<IActionResult> Update(int id, [FromBody] Book model)
        {
            if (model == null || id != model.BookId)
            {
                return BadRequest("Book data is invalid");
            }

            var bookFromDb = await _context.Book.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound("Book not found");
            }

            if (ModelState.IsValid)
            {
                bookFromDb.ReleaseYear = model.ReleaseYear;
                bookFromDb.Author = model.Author;
                bookFromDb.BookName = model.BookName;

                _context.Book.Update(bookFromDb);
                await _context.SaveChangesAsync();
                return Ok(bookFromDb);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}", Name = "DeleteContact")]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _context.Book.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound("Book not found");
            }

            _context.Book.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return Ok("Book Deleted");
        }
    }



}
