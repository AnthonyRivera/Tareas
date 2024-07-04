using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge_1.Models;

namespace CodingChallenge_1.Interfaces
{
	public interface IAuthorRepository
	{
		int Add(Author author);
		void Update(Author author);
		void Delete(int id);
		Author GetById(int id);
		List<Author> GetAll();
	}
}
