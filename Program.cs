using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please input the RPN array, use comma to split the digital & operator\r\n\r\n");
                String rpnArray = Console.ReadLine();
                Console.WriteLine("Your proposed Reverse Polish Notation is: '" + rpnArray + "'\r\n");
                RpnExpression rpnEx = new RpnExpression(rpnArray);
                //Console.WriteLine(rpnEx.IsInputValid);
                Console.WriteLine("The calculated value of the RPN expression is: '" + rpnEx.calculate() + "'\r\n\r\n");
                Console.WriteLine("Please click one more time to close the dialoge.\r\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
