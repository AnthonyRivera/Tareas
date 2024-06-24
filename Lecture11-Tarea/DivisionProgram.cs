using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture11_Tarea
{
    public class DivisionProgram
    {
        public void DivisonProgram()
        {
            Console.WriteLine("This is a program to get the result division of two numbers.");
            try
            {
                
                Console.WriteLine("Input number:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Input number you want to divide it to:");
                int num2 = int.Parse(Console.ReadLine());

                if (num1 < 0 || num2 < 0)
                {
                    throw new NegativeNumberException("You have inputted a negative number.");
                }

                int result = num1 / num2;
                Console.WriteLine($"The result for the division of the two numbers is: {num1} / {num2} = {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Number has to be the correct format.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Number can't be divided by 0.");
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution block try-catch has ended.");
            }
        }
    }
}
