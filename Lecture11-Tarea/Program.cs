using Lecture11_Tarea;

class Program
{
    static void Main(string[] args)
    {
        DivisionProgram div = new DivisionProgram();
        div.DivisonProgram();

        ContactManager manager = new ContactManager();
        Contact contact1 = new Contact { Id = 1, Name = "Juancho", Email = "juancho.nieves1@mipe.com" };
        Contact contact2 = new Contact { Id = 2, Name = "", Email = "anthony@turnospr.com" }; 

        manager.AddContact(contact1);
        manager.AddContact(contact2);
        List<Contact> allContacts = manager.GetAllContacts();
        Console.WriteLine("Contacts saved:");
        foreach (var contact in allContacts)
        {
         Console.WriteLine($"ID: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}");
        }
        Console.ReadLine();
    }
    
}