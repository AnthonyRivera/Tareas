using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture8_Tarea
{
    public interface IContactManager
    {
        void AddContact(string contact);
        void UpdateContact(string contact, string newcontact);
        void DeleteContact(string contact);
        List<string> GetAllContacts();

    }
}
