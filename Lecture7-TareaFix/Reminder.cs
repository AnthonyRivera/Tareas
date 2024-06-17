using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7_TareaFix
{
    public class Reminder:Contact
    {
        public string appointment {  get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public string place {  get; set; }

        public string remind = "";
        
        public void CreateReminder(string appoint, string t, string d, ref string remind)
        {
            appointment = appoint;
            time = t;
            date = d;
            remind=appoint+" "+t+" "+d;
        }
        public void CreateReminder(string appoint, string t, string d,string p, ref string remind)
        {
            appointment = appoint;
            time = t;
            date = d;
            place = p;
            remind = appoint + " " + t + " " + d;
        }
        public void CreateReminder(string name, string appoint, string p, decimal phone, ref string remind)
        {
            ContactName = name;
            appointment = appoint;
            place = p;
            ContactPhone = phone;
            
            remind = appoint + " " + p + " " + name + " "+phone;
        }
        public void CreateReminder(string name, decimal phone, string mail, string appoint, string p,string d , ref string remind)
        {
            ContactName = name;
            ContactPhone = phone;
            ContactEmail= mail;
            appointment = appoint;
            place = p;
            date = d;
            remind = name + " " + phone + " " + mail + appoint + " " + p + " " + d;
        }



    }
}
