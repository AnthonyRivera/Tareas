using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge_1.Models;

namespace CodingChallenge_1.Interfaces
{
	public interface IBookRepository
	{
		int Add(Book book);
		void Update(Book  book);
		void Delete(int id);
		Book GetById(int id);
		List<Book> GetAll();
	}
}
