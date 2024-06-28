using Lecture14_Tarea.Context;
using Lecture14_Tarea.Contracts;
using Lecture14_Tarea.Models;
using Lecture14_Tarea.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var options = new DbContextOptionsBuilder<ApplicationContext>()
    .UseSqlServer(ConfigurationManager.ConnectionStrings["ContactesDbCnn"].ConnectionString)
    .Options;

var context = new ApplicationContext(options);

IContactRepository contactRepository = new ContactAdoRepository();

var newContact = new Contact
{
    Name = "Sans",
    LastName = "Chara",
    Email = "intheendisjustme@undertale.com",
};


int newId= contactRepository.Add(newContact);
var contact = contactRepository.GetById(newId);
Console.WriteLine($"Contact retrieved: {contact.Name} {contact.LastName}");

newContact.Email = "john.doe@newemail.com";
contactRepository.Update(newContact);
Console.WriteLine("Contact updated.");

var contacts = contactRepository.GetAll();
foreach (var c in contacts)
{
    Console.WriteLine($"{c.Name} {c.LastName}");
}

contactRepository.Delete(newId);
Console.WriteLine("Contact deleted.");