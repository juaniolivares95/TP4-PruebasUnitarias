using System.Collections.Generic;

namespace ProductModule.StockSystem
{
    public class StockServiceConnection
    {
        public bool Exists(string SKU)
        {
            return products.Contains(SKU);
        }

        private readonly static List<string> products = new()
        {
            "100",
            "200",
            "300",
            "400",
            "500"
        };
    }
}
