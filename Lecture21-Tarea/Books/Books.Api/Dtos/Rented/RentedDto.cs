using Books.Domain.Models;

namespace Books.Api.Dtos.Rented
{
    public class RentedDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
    }
}
