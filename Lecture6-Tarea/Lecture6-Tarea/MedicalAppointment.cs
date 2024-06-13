namespace Lecture6_Tarea
{
    public class MedicalAppointment: Person
    {
        public string Fecha { get; set; }
        public string Reason { get; set; }
        public void MessageFromPartialExtended()
        {
            Console.WriteLine("Por favor llene su información personal para cita médica.");
        }
        public void WritDate()
        {
            Console.WriteLine($"La fecha de su cita es (de forma númerica): ");
            Fecha = Console.ReadLine();
        }
        public void WriteReasonOfAppointment()
        {
            Console.WriteLine($"Razón para cita: ");
            Reason = Console.ReadLine();
        }
        public void WriteInformación()
        {
            Console.WriteLine($"Su nombre es: {Name} {LastName}, edad: {Age}, sexo:{Sex}");
            Console.WriteLine($"Fecha de suu visita: {Fecha} y la razón es:{Reason}");
        }
    }
}
