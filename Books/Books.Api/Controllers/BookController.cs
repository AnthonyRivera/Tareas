using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Books.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Book> Get()
        {
            var booksFromDb = _bookRepository.GetAll();
            return booksFromDb;
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
        public async Task<IActionResult> Create([FromBody] Book model)
        {
            if (model == null)
            {
                return BadRequest("Book data is null");
            }

            if (ModelState.IsValid)
            {
                
                _context.Book.Add(model);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetBook", new { id = model.BookId }, model);
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
                return NotFound("Contact not found");
            }

            _context.Book.Remove(bookFromDb);
            await _context.SaveChangesAsync();
            return Ok("Contact Deleted");
        }
    }



}
