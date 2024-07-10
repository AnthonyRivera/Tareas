using Books.Persistence.Context;
using Books.Web.Interfaces;
using Books.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Lecture19_Tarea.Controllers
{
    public class BookController:Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ApplicationContext _context;
        private readonly BookAdoRepository _bookAdoRepository;
        public BookController(ApplicationContext context, IBookRepository bookRepository, BookAdoRepository bookAdoRepository)
        {
            _bookRepository = bookRepository;
            _context = context;
            _bookAdoRepository = bookAdoRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var cotacts = _context.Contacts.ToList();
            var books = _bookRepository.GetAll();
            return View(books);
        }
    }
}
