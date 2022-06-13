using System.Collections.Generic;

namespace ProductModule.Request
{
    public class RequestAddProduct
    {
        public string Name { get; set; }
        public long ProductTypeId { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal XSize { get; set; }
        public decimal YSize { get; set; }
        public decimal ZSize { get; set; }
        public decimal Price { get; set; }

    }
}
