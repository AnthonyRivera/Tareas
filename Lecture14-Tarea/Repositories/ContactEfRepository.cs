using Lecture14_Tarea.Context;
using Lecture14_Tarea.Contracts;
using Lecture14_Tarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture14_Tarea.Repositories
{
    public class ContactEfRepository : IContactRepository
    {
        private readonly ApplicationContext _context;
        public ContactEfRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            _context.Contact.Add(contact);
            _context.SaveChanges();
            return contact.ContactId;

        }

        public void Delete(int id)
        {
            var contactFromDb = GetById(id);
            if (contactFromDb != null)
            {
                _context.Remove(contactFromDb);
                _context.SaveChanges();
            }
        }

        public Contact GetById(int id)
        {
            // var contactFromDb = _context.Contacts.FirstOrDefault(x => x.Id == id);
            //if (contactFromDb == null)
            //{
            //    return null;
            //}
            //return contactFromDb;
            return _context.Contact.FirstOrDefault(x => x.ContactId == id);

        }

        public List<Contact> GetAll()
        {
            return _context.Contact.ToList();

        }

        public void Update(Contact contact)
        {
            var contactFromDb = GetById(contact.ContactId);
            if (contactFromDb != null)
            {
                contactFromDb.Email = contact.Email;

                _context.Contact.Update(contactFromDb);
                _context.SaveChanges();
            }
            //_context.Contacts.Update(contact);
            //_context.SaveChanges();

        }
    }
}
