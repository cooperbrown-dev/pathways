using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC
{
    class CalcController
    {
        private CalcModel aCalc;
        private CalcView aView;

        public CalcController()
        {
            aView = new CalcView();
            aCalc = new CalcModel();
        }

        public void Run()
        {
            aView.DisplayTitle();

            bool endApp = false;

            while (!endApp)
            {
                aCalc.Number1 = aView.GetDoubleFromUser();
                aCalc.Number2 = aView.GetDoubleFromUser();
                aCalc.Operator = aView.GetOperator();

                try
                {
                    double result = aCalc.DoOperation(aCalc.Number1, aCalc.Number2, aCalc.Operator);  // invokes the DoOperation method of the object and passes the operation

                    if (double.IsNaN(result))
                    {
                        aView.IfNan();
                    }
                    aView.ShowCalculation(result);
                }
                catch (Exception e)
                {
                    aView.CatchExcE();
                }
                endApp = aView.AskUserToContinueOrQuit();
            }
        } // end loop
    }
}
