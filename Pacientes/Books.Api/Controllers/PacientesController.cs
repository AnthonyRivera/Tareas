using AutoMapper;
using Books.Api.Dtos.Books;
using Books.Api.Helpers;
using Books.Api.Responses;
using Books.Application.Interfaces;
using Books.Domain.Models;
using Books.Persistence.Context;
using Books.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController:ControllerBase
    {
        private readonly IPacienteService _bookService;

        private readonly IMapper _mapper;
       // private readonly ApplicationContext _context;
        //private readonly BookAdoRepository _bookAdoRepository;


        public PacientesController(IPacienteService context, IMapper mapper) { 
 
            _bookService = context;

            _mapper = mapper;
            //_context= context;
           // _bookAdoRepository = bookAdoRepository;

        }

        [HttpGet(Name = "GetPacientes")]
        public async Task<PacienteResponse> GetAsync()
        {
            /* var response = new BookResponse();
             response.Message = "Todo Bien";
             var booksFromDb = _bookRepository.GetAll();
             var booksToReturn = new List< BookDto > ();
             foreach (var book in booksFromDb)
             {
                 *//*booksToReturn.Add(new BookDto
                 {
                     BookName = book.BookName,
                     Author = book.Author,
                     ReleaseYear = book.ReleaseYear
                 });*//*
                 booksToReturn.Add(BookHelper.ToBookDto(book));
             }
             response.Books = booksToReturn;
             return response;*/
            var booksFromDb = await _bookService.GetAllPacientes();

            var booksToReturn = _mapper.Map<List<PacienteDto>>(booksFromDb);

            return new PacienteResponse { Pacientes = booksToReturn, Message = "Todo Bien" };
        }

        [HttpGet("{id}", Name = "GetPaciente")]
        public async Task<ActionResult<Paciente>> Get(int id)
        {
            /*var booksFromDb = _context.Book.FirstOrDefault(p => p.BookId == id);
            if (booksFromDb == null)
            {
                return NotFound("Book not found");
            }
            return Ok(booksFromDb);*/
            var bookFromDb = await _bookService.GetPacienteById(id);

            if (bookFromDb == null)

            {

                return NotFound("Paciente not found");

            }

            var bookToReturn = _mapper.Map<PacienteDto>(bookFromDb);

            return Ok(bookToReturn);
        }

        [HttpPost(Name = "CreatePaciente")]
        public async Task<IActionResult> Create([FromBody] PacienteBookDto model)
        {
            if (model == null)
            {
                return BadRequest("Paciente data is null");
            }

            if (ModelState.IsValid)
            {
                /*var bookDb = new Book
                {
                    BookName = model.BookName,
                    Author=model.Author,
                    ReleaseYear =model.ReleaseYear

                };*/
                /* var bookDb = BookHelper.ToBook(model);

                 _context.Book.Add(bookDb);
                 model.BookId = bookDb.BookId;
                 await _context.SaveChangesAsync();
                 return CreatedAtRoute("GetBook", new { id = bookDb.BookId }, model);*/
                var bookToCreate = _mapper.Map<Paciente>(model);

                await _bookService.AddPaciente(bookToCreate);

                var bookToReturn = _mapper.Map<PacienteDto>(bookToCreate);

                model.ID = bookToCreate.ID;

                return CreatedAtRoute("GetPaciente", new { id = bookToCreate.ID }, model);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdatePaciente")]
        public async Task<IActionResult> Update(int id, [FromBody] PacienteBookDto model)
        {
            if (model == null || id != model.ID)
            {
                return BadRequest("Paciente data is invalid");
            }

            /*var bookFromDb = await _context.Book.FindAsync(id);
           *//* if (bookFromDb == null)*//*
            {
                return NotFound("Book not found");
            }*/

            if (ModelState.IsValid)
            {
                /*bookFromDb.ReleaseYear = model.ReleaseYear;
                bookFromDb.Author = model.Author;
                bookFromDb.BookName = model.BookName;

                _context.Book.Update(bookFromDb);
                await _context.SaveChangesAsync();
                return Ok(bookFromDb);*/
                var bookToUpdate = _mapper.Map<Paciente>(model);

                await _bookService.UpdatePaciente(bookToUpdate);

                return Ok(model);

            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}", Name = "DeletePaciente")]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _bookService.GetPacienteById(id);

            if (bookFromDb == null)
            {
                return NotFound("Book not found");
            }

            _bookService.DeletePaciente(bookFromDb.ID);
            return Ok("Paciente Deleted");
        }
    }



}
