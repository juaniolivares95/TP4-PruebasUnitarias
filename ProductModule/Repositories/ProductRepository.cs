using ProductModule.Models;
using System.Collections.Generic;

namespace ProductModule.Repositories
{
    public class ProductRepository
    {
        public bool NameExists(string name)
        {
            return DummyProductList.Exists(p => p.Name == name);
        }

        public bool Create(ProductModel product)
        {
            DummyProductList.Add(product);
            return true;
        }

        public bool SKUExists(string SKU)
        {
            return DummyProductList.Exists(p => p.SKU == SKU);
        }

        private readonly List<ProductModel> DummyProductList = new();
    }
}
