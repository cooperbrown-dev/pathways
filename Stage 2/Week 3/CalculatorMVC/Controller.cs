using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class Controller
    {
        private Model aCalc;
        private View aView;

        public Controller()
        {
            aView = new View();

            aCalc = new Model();


        }
    }
}
