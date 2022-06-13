using ProductModule.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductModule.Repositories
{
    public class ProductTypeRepository
    {
        public ProductType GetById(long id)
        {
            return DummyTypesList.Find(p => p.Id == id);
        }
        public bool IdExists(long id)
        {
            return DummyTypesList.Exists(p => p.Id == id);
        }
        public bool NameExists(string name)
        {
            return DummyTypesList.Exists(p => p.Name == name);
        }

        public bool FeaturesExists(List<string> features)
        {
            return DummyTypesList.Exists(p => features.All(p.Features.Contains) && features.Count == p.Features.Count());
        }

        public bool Create(ProductType product)
        {
            DummyTypesList.Add(product);
            return true;
        }

        private readonly List<ProductType> DummyTypesList = new();
    }
}
