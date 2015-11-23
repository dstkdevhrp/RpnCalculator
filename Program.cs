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
                Console.Write("Please input the RPN array, use comma to split the digital & operator\r\n");
                String rpnArray = Console.ReadLine();
                Console.WriteLine("Your proposed Reverse Polish Notation is: '" + rpnArray + "'");
                RpnExpression rpnEx = new RpnExpression(rpnArray);
                //Console.WriteLine(rpnEx.IsInputValid);
                Console.WriteLine("The calculated value of the RPN expression is: '" + rpnEx.calculate() + "'");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
