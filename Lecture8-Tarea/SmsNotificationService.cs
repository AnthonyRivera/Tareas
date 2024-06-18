using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture8_Tarea
{
    public class SmsNotificationService:INotificationService
    {
        public void SendNotification(string notification)
        {
            Console.WriteLine($"Sending SMS notification: {notification}");
        }
    }
}
