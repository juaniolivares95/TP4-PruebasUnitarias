using System;

namespace ProductModule.Models
{
    public class ProductPrice : BaseModel
    {
        public decimal Price { get; set;}
        public DateTime TimeStamp { get; set;}
    }
}
