using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcController c = new CalcController();
            c.Run();
        }
    }
}