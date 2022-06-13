using System.Collections.Generic;

namespace ProductModule.Models
{
    public class ProductType : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Features { get; set; }
    }
}
