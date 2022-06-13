using System.Collections.Generic;

namespace ProductModule.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal XSize { get; set; }
        public decimal YSize { get; set; }
        public decimal ZSize { get; set; }
        public IEnumerable<ProductPrice> Prices { get; set; }

    }
}
