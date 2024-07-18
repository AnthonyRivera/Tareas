using Books.Api.Dtos.Books;
using Books.Domain.Models;

namespace Books.Api.Responses
{
    public class PacienteResponse
    {
        public string Message {  get; set; }
        public List<PacienteDto> Pacientes { get; set; }
    }
}
