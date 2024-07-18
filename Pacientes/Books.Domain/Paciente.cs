using System.ComponentModel.DataAnnotations;

namespace Books.Domain.Models
{
    public class Paciente
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }

        public int age { get; set; }
    }
}
