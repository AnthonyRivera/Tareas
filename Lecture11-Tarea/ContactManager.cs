namespace Lecture11_Tarea
{
    public class ContactManager
    {
        public List<Contact> contacts;

        public ContactManager()
        {
            contacts = new List<Contact>();
        }


        public void AddContact(Contact newContact)
        {
            Console.WriteLine("This is a program to add Contacts.");
            try
            {
                if (string.IsNullOrWhiteSpace(newContact.Name))
                {
                    throw new ArgumentException("Contact name cannot be empty.");
                }
                foreach (var contact in contacts)
                {
                    if (contact.Id == newContact.Id)
                    {
                        throw new DuplicateContactException($"A contact with ID {newContact.Id} already exists.");
                    }
                }
                contacts.Add(newContact);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error adding contact: {ex.Message}");
            }
            catch (DuplicateContactException ex)
            {
                Console.WriteLine($"Error adding contact: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finished adding contact operation.");
            }
        }
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
    }
}
