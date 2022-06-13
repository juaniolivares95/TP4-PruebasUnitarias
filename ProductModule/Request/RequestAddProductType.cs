using System.Collections.Generic;

namespace ProductModule.Request
{
    public class RequestAddProductType
    {
        public string Name { get; set; }
        public List<string> Features { get; set; }
    }
}
