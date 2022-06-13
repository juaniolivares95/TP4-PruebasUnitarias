using ProductModule.Helpers;
using ProductModule.Models;
using ProductModule.Repositories;
using ProductModule.Request;
using ProductModule.StockSystem;
using System;
using System.Collections.Generic;

namespace ProductModule.Services
{
    public class ProductService : BaseService
    {
        private readonly StockServiceConnection _stockServiceConnection;
        private readonly ProductRepository _productRepository;
        private readonly ProductTypeRepository _productTypeRepository;

        public ProductService(StockServiceConnection stockServiceConnection, ProductRepository productRepository, ProductTypeRepository productTypeRepository)
        {
            _stockServiceConnection = stockServiceConnection;
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
        }

        public GenericResponse<long> AddProduct (RequestAddProduct request) 
        {
            if (request.Price <= 0)
            {
                return Error<long>(ErrorsEnum.PRICE_NOT_VALID); 
            }

            if (!_stockServiceConnection.Exists(request.SKU))
            {
                return Error<long>(ErrorsEnum.SKU_DOESNT_EXIST);
            }

            if (_productRepository.SKUExists(request.SKU))
            {
                return Error<long>(ErrorsEnum.SKU_NOT_UNIQUE);
            }

            if(_productRepository.NameExists(request.Name))
            {
                return Error<long>(ErrorsEnum.NAME_NOT_UNIQUE);
            }

            if (request.ZSize <= 0 ||request.XSize <= 0 ||request.YSize <= 0)
            {
                return Error<long>(ErrorsEnum.SIZE_NOT_VALID);
            }

            var product = new ProductModel()
            {
                Id = new Random().Next(),
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                ProductType = _productTypeRepository.GetById(request.ProductTypeId),
                Weight = request.Weight,
                XSize = request.XSize,
                YSize = request.YSize,
                ZSize = request.ZSize,
                Prices = new List<ProductPrice>() { new ProductPrice() { Price = request.Price, TimeStamp = DateTime.Now } },
            };

            _productRepository.Create(product);

            return Ok<long>(product.Id, "Producto creado con éxito");
        }
    }
}
