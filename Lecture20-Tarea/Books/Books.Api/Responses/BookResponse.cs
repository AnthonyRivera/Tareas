using Books.Api.Dtos.Books;
using Books.Domain.Models;

namespace Books.Api.Responses
{
    public class BookResponse
    {
        public string Message {  get; set; }
        public List<BookDto> Books { get; set; }
    }
}
