using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture14_Tarea.Models;

namespace Lecture14_Tarea.Contracts
{
    public interface IContactRepository
    {
        int Add(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
        Contact GetById(int id);
        List<Contact> GetAll();
    }
}
