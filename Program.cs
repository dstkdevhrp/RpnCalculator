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
            String handle = "1";
            do
            {
                try
                {
                    Console.Write("Please select the decimal delimiter type, [1]comma, [2]point\r\n\r\n");

                    char dl = '1';
                    while (dl.Equals('1'))
                    {
                        String spliter = Console.ReadLine();
                        if (spliter.Equals("1"))
                        {
                            dl = ',';
                        }
                        else if (spliter.Equals("2"))
                        {
                            dl = '.';
                        }
                        else
                        {
                            Console.Write("Please input correct option, [1]comma, [2]point\r\n\r\n");
                        }
                    }

                    Console.Write("Please input the RPN array, use space to split the digital & operator arrays ...\r\n\r\n");
                    String rpnArray = Console.ReadLine();
                    Console.WriteLine("Your proposed Reverse Polish Notation is: '" + rpnArray + "'\r\n");
                    RpnExpression rpnEx = new RpnExpression(rpnArray, dl);
                    //Console.WriteLine(rpnEx.IsInputValid);
                    double result = rpnEx.calculate();
                    String re = result.ToString();
                    if (dl.Equals(','))
                    {
                        re = result.ToString().Replace(".", ",");
                    }
                    Console.WriteLine("The calculated value of the RPN expression is: '" + re + "'\r\n\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Please select next step, [1]Continue, [Others]Close & Exit\r\n");
                handle = Console.ReadLine();
            }
            while (handle.Equals("1"));

        }
    }
}
