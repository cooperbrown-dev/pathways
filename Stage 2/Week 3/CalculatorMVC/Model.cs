using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class Model
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        //defualt constructor
        public Model()
        {
            Number1 = 0;
            Number2 = 0;
        }

        //overloaded constructor
        public Model(double num1, double num2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public double DoOperation (double num1, double num2) {
            double result = double.NaN;

            switch (Op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // check for a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
