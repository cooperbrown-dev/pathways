using System;

namespace InterfaceAndDI
{
    public class DogLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Inside Log method of DogLogger.");
            LogToDog(message);
        }
        private void LogToDog(string message)
        {
            Console.WriteLine("Method: LogToDog, Text: {0}", message);
        }
    }
}