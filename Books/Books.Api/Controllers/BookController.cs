using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController:ControllerBase
    {
        private readonly IBookRepository _context;

        public BookController(IBookRepository context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBooks")]
        public IEnumerable<Book> Get()
        {
            var booksFromDb = _context.GetAll();
            return booksFromDb;
        }
    }
}
