// See https://aka.ms/new-console-template for more information
using Lecture8_Tarea;

Console.WriteLine("Hello, World!");


IContactManager contactManager = new ContactManager();
contactManager.AddContact("Luis");
contactManager.AddContact("Roberto");

List<string> contacts = contactManager.GetAllContacts();
foreach (var c in contacts)
{
    Console.WriteLine(c);
}
Console.WriteLine($"");
contactManager.UpdateContact("Luis", "Antonio");
foreach (var c in contacts)
{
    Console.WriteLine(c);
}
Console.WriteLine($"");
contactManager.DeleteContact("Antonio");
foreach (var c in contacts)
{
    Console.WriteLine(c);
}
Console.WriteLine($"");
INotificationService emailService = new EmailNotificationService();
emailService.SendNotification("Te llego un correo de prueba.");

INotificationService smsService = new SmsNotificationService();
smsService.SendNotification("Te llego un mensaje SMS de prueba.");

Console.ReadLine();