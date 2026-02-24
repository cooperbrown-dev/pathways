using System;

namespace InterfaceAndDI
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderFood loggerFile = new DogLogger();
            //ILogger loggerFile = new FileLogger();

            ProductService productService1 = new ProductService(loggerFile);
            productService1.Log("New log entry.");

        }
    }
}