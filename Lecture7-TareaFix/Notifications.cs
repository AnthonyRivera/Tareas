// See https://aka.ms/new-console-template for more information
using Lecture7_TareaFix;
Console.WriteLine("Hello, World!");
Notification();


    static void Notification()
    {
        var Reminding = new Reminder();
        string Notif = "";
        Reminding.CreateReminder("tony", "cita medica", "hospital", 7879990999, ref Notif);
        Console.WriteLine($"Here is information about you appointment today: {Notif}");
    }