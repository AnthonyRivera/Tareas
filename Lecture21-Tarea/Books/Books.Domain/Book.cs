using System.ComponentModel.DataAnnotations;

namespace Books.Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string ReleaseYear { get; set; }
        public List<Rented> Renteds { get; set; }
    }
}
