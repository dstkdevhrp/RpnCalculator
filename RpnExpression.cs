using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalculator
{
    public class RpnExpression
    {
        private static string INVALID_STR_ERRMSG = "Input array invalid";
        private static string NUMBER_OPERATOR_ERRMSG = "Number of operator and digital is incorrect";
        private static string OPERATOR_POSITION_ERRMSG = "Position of operator is incorrect";
        private Stack rpnStack;

        public char Delimiter
        {
            get;
            set;
        }

        public String InputStr
        {
            get;
            set;
        }

        public bool IsInputValid
        {
            get;
            set;
        }

        public RpnExpression()
        {

        }

        public RpnExpression(String input, char dl)
        {
            this.Delimiter = dl;
            this.InputStr = input;
            this.validInput(input, dl);
        }

        public double calculate()
        {
            if (!IsInputValid)
            {
                throw new Exception(INVALID_STR_ERRMSG);
            }

            double result = 0;

            // Use a stack to help record temporary calculation parameters
            String[] isa = InputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            rpnStack = new Stack();

            for (int i = 0; i < isa.Length; i++)
            {
                String ss = isa[i];

                if (isOperator(ss))
                {
                    String right = rpnStack.Pop().ToString();
                    String left = rpnStack.Pop().ToString();
                    if (String.IsNullOrEmpty(right) || String.IsNullOrEmpty(left))
                    {
                        throw new Exception(INVALID_STR_ERRMSG);
                    }

                    if (Delimiter.Equals(','))
                    {
                        left = left.Replace(',', '.');
                        right = right.Replace(',', '.');
                    }

                    double lv = double.Parse(left);
                    double rv = double.Parse(right);
                    double r = calculate(lv, rv, ss);

                    rpnStack.Push(Convert.ToString(r));
                    result = r;
                }
                else
                {
                    rpnStack.Push(ss);
                }
            }

            return result;
        }

        public double calculate(double left, double right, string op)
        {
            double result = 0;

            switch (op)
            {
                case "+":
                    {
                        result = left + right;
                        break;
                    }
                case "-":
                    {
                        result = left - right;
                        break;
                    }
                case "*":
                    {
                        result = left * right;
                        break;
                    }
                case "/":
                    {
                        result = left / right;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return result;
        }

        public bool validInput(String input, char dl)
        {
            String[] inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            IsInputValid = true;
            int opNum = 0;
            int dgNum = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                String item = inputArray[i];

                if (this.isOperator(item))
                {
                    if (i == 0 || i == 1)
                    {
                        IsInputValid = false;
                        Console.WriteLine(OPERATOR_POSITION_ERRMSG);
                        break;
                    }
                    opNum++;
                }
                else if (this.isDouble(item, dl))
                {   
                    dgNum++;
                }
                else
                {
                    IsInputValid = false;
                    Console.WriteLine(INVALID_STR_ERRMSG + "'" + inputArray[i] + "' is not a operator, integer or double");
                    break;
                }
            }

            if (IsInputValid)
            {
                // Count of Digi-numbers must bigger than operator number only 1
                if (dgNum - opNum != 1)
                {
                    IsInputValid = false;
                    Console.WriteLine(NUMBER_OPERATOR_ERRMSG);
                }
            }

            return IsInputValid;
        }

        public bool isOperator(String oper)
        {
            bool isOp = false;

            String op = oper.Trim();

            if (op.Equals("+") || op.Equals("-") || op.Equals("*") || op.Equals("/"))
            {
                isOp = true;
            }

            return isOp;
        }

        public bool isDouble(String floatNum, char dl)
        {
            bool isDouble = false;
            double res = 0;

            if (floatNum.Contains(",") && dl.Equals('.'))
            {
                return false;
            }

            if (floatNum.Contains(".") && dl.Equals(','))
            {
                return false;
            }

            String fn = floatNum;
            if (dl.Equals(','))
            {
                fn = fn.Replace(',', '.');
            }
            if (double.TryParse(fn, out res))
            {
                isDouble = true;
            }

            return isDouble;
        }
    }
}
