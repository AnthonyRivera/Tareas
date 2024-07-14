using Books.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain
{
    public class Rented
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public Book Book { get; set; }
    }
}
