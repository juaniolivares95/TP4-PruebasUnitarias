using NUnit.Framework;
using ProductModule.Helpers;
using ProductModule.Repositories;
using ProductModule.Request;
using ProductModule.Services;
using System.Collections.Generic;

namespace TestProductModule
{
    public class ProductTypeTests
    {
        private ProductTypeService _service;

        [SetUp]
        public void Setup()
        {
            _service = new(new ProductTypeRepository());
        }

        [Test]
        public void CheckEmptyFeatures()
        {
            // Arrange
            RequestAddProductType request = new RequestAddProductType()
            {
                Name = "Tablets",
                Features = new List<string>()
            };

            // Act
            var result = _service.AddProductType(request);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.NO_FEATURES);
        }
        
        [Test]
        public void CheckUniqueName()
        {
            // Arrange
            RequestAddProductType request1 = new()
            {
                Name = "Tablets",
                Features = new List<string>() { "Pantalla" }
            };

            RequestAddProductType request2 = new()
            {
                Name = "Tablets",
                Features = new List<string>() { "Almacenamiento" }
            };

            _service.AddProductType(request1);

            // Act
            var result = _service.AddProductType(request2);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.NAME_NOT_UNIQUE);
        }

        [Test]
        public void CheckUniqueFeatures()
        {
            // Arrange
            RequestAddProductType request1 = new()
            {
                Name = "Tablets",
                Features = new List<string>() { "Almacenamiento" , "Pantalla", "Disco" }
            };

            RequestAddProductType request2 = new()
            {
                Name = "Computadoras",
                Features = new List<string>() { "Almacenamiento", "Pantalla", "Disco" }
            };

            _service.AddProductType(request1);

            // Act
            var result = _service.AddProductType(request2);

            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.FEATURES_NOT_UNIQUE);
        }


    }
}