using System;

namespace InterfaceAndDI
{
    public class ProductService : IOrderFood
    {
        private readonly IOrderFood _logger;
        public ProductService(IOrderFood logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}