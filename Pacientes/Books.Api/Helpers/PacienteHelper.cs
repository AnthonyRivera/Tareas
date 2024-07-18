using Books.Api.Dtos.Books;
using Books.Domain.Models;

namespace Books.Api.Helpers
{
    public class BookHelper
    {
        public static PacienteDto ToBookDto(Paciente book)
        {
            return new PacienteDto
            {
                ID=book.ID,
                FirstName = book.FirstName,
                LastName = book.LastName,
                Sex = book.Sex,
                age = book.age
            };
        }
        public static Paciente ToBook(PacienteDto dto)
        {
            return new Paciente
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Sex = dto.Sex,
                age = dto.age
            };
        }
        public static Paciente ToBook(PacienteBookDto dto)
        {
            return new Paciente
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Sex = dto.Sex,
                age = dto.age
            };
        }
    }
}
