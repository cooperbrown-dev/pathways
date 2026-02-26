namespace CalculatorMVC
{
    public class CalcController
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
                    double result = aCalc.DoOperation();  // invokes the DoOperation method of the object and passes the operation

                    aView.ShowCalculation(result);
                }
                catch (Exception e)
                {
                    aView.CatchExcE(e.Message);
                }
                endApp = aView.AskUserToContinueOrQuit();
            }
        } // end loop
    }
}
