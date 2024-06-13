namespace Lecture6_Tarea
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public void MessageFromPartialExtended()
        {
            Console.WriteLine("Por favor llene su información personal.");
        }
        public void WriteName()
        {
            Console.WriteLine($"Mi nombre es: ");
            Name = Console.ReadLine();
        }
        public void WriteLastName()
        {
            Console.WriteLine($"Mi apellido es: ");
            LastName = Console.ReadLine();
        }
        public void WriteAge()
        {
            string userInput;
            Console.WriteLine($"Mi edad es: ");
            userInput = Console.ReadLine();
            /* Converts to integer type */
             Age= Convert.ToInt32(userInput);
            
        }
        public void WriteSex()
        {
            Console.WriteLine($"Mi sexo es: ");
            Sex = Console.ReadLine();
        }
       

    }
}
