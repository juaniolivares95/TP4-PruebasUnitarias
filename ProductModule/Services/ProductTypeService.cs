using ProductModule.Helpers;
using ProductModule.Models;
using ProductModule.Repositories;
using ProductModule.Request;
using ProductModule.StockSystem;

namespace ProductModule.Services
{
    public class ProductTypeService : BaseService
    {
        private readonly ProductTypeRepository _productTypeRepository;

        public ProductTypeService(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public GenericResponse<long> AddProductType (RequestAddProductType request) 
        {
            if (request.Features.Count <= 0)
            {
                return Error<long>(ErrorsEnum.NO_FEATURES); 
            }

            if (_productTypeRepository.NameExists(request.Name))
            {
                return Error<long>(ErrorsEnum.NAME_NOT_UNIQUE);
            }

            if (_productTypeRepository.FeaturesExists(request.Features))
            {
                return Error<long>(ErrorsEnum.FEATURES_NOT_UNIQUE);
            }


            var product = new ProductType()
            {
                Name = request.Name,
                Features = request.Features
            };

            _productTypeRepository.Create(product);

            return Ok<long>(1, "Tipo de producto creado con éxito");
        }
    }
}
