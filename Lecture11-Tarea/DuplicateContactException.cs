using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Tarea
{
    public class DuplicateContactException : Exception
    {
        public DuplicateContactException(string message):base(message) { 
        }
    }
}
