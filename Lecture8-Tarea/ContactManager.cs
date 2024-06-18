using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture8_Tarea
{
    public class ContactManager : IContactManager
    {
        private List<string> contacts;

        public ContactManager() { 
            contacts = new List<string>();
        }
        public void AddContact(string contact) { 
        contacts.Add(contact);
        }
        public void DeleteContact(string contact)
        {
           String existingContact = contacts.Find(c=>c.Equals(contact));
            if (existingContact != null)
            {
                contacts.Remove(existingContact);
            }
            else {
                Console.WriteLine($"The contact {contact} isn't found.");
                }
        }
        public void UpdateContact(string contact, string newcontact)
        {
            String existingContact = contacts.Find(c => c.Equals(contact));
            if (existingContact != null)
            {
                contacts.Remove(existingContact);
                contacts.Add(newcontact);
            }
            else
            {
                Console.WriteLine($"The contact {contact} isn't found.");
            }
        }
        public List<string> GetAllContacts() { 
            return contacts;
        }
    }
}
