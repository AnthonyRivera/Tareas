using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7_TareaFix
{
    public class Contact
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        
        public decimal ContactPhone { get; set; }

        public void CreateContact(string name, string email, decimal phone)
        {
            ContactName = name;
            ContactEmail = email;
            ContactPhone = phone;
        }
        public void CreateContact(string name, string email, decimal phone, ref string contact)
        {
            ContactName=name;
            ContactEmail=email;
            ContactPhone = phone;
            contact=name+email+phone;
        }
    }
}
