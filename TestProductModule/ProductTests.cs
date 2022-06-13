using NUnit.Framework;
using ProductModule.Helpers;
using ProductModule.Repositories;
using ProductModule.Request;
using ProductModule.Services;
using ProductModule.StockSystem;

namespace TestProductModule
{
    public class ProductTests
    {
        private ProductService _service;

        [SetUp]
        public void Setup()
        {
            _service = new(new StockServiceConnection(), new ProductRepository(), new ProductTypeRepository());
        }

        [Test]
        public void CheckUniqueProductName()
        {
            // Arrange
            RequestAddProduct request1 = new()
            {
                Name = "Lenovo Thinkpad L14",
                ProductTypeId = 1,
                SKU = "100",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 4,
                XSize = 30,
                YSize = 10,
                ZSize = 20,
                Price = 126000,
            };

            RequestAddProduct request2 = new()
            {
                Name = "Lenovo Thinkpad L14",
                ProductTypeId = 2,
                SKU = "200",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 5,
                XSize = 32,
                YSize = 12,
                ZSize = 23,
                Price = 126500,
            };

            _service.AddProduct(request1);

            // Act
            var result = _service.AddProduct(request2);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.NAME_NOT_UNIQUE);
        }
        [Test]
        public void CheckUniqueProductSKU()
        {
            // Arrange
            RequestAddProduct request1 = new()
            {
                Name = "Lenovo Thinkpad L13",
                ProductTypeId = 1,
                SKU = "100",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 4,
                XSize = 30,
                YSize = 10,
                ZSize = 20,
                Price = 126000,
            };

            RequestAddProduct request2 = new()
            {
                Name = "Lenovo Thinkpad L14",
                ProductTypeId = 2,
                SKU = "100",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 5,
                XSize = 32,
                YSize = 12,
                ZSize = 23,
                Price = 126500,
            };

            _service.AddProduct(request1);

            // Act
            var result = _service.AddProduct(request2);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.SKU_NOT_UNIQUE);
        }
        [Test]
        public void CheckSKUExists()
        {
            // Arrange
            RequestAddProduct request = new()
            {
                Name = "Lenovo Thinkpad L13",
                ProductTypeId = 1,
                SKU = "800",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 4,
                XSize = 30,
                YSize = 10,
                ZSize = 20,
                Price = 126000,
            };

            // Act
            var result = _service.AddProduct(request);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.SKU_DOESNT_EXIST);
        }
        [Test]
        public void CheckValidProductPrice()
        {
            // Arrange
            RequestAddProduct request = new()
            {
                Name = "Lenovo Thinkpad L13",
                ProductTypeId = 1,
                SKU = "800",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 4,
                XSize = 30,
                YSize = 10,
                ZSize = 20,
                Price = 0,
            };

            // Act
            var result = _service.AddProduct(request);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.PRICE_NOT_VALID);
        }
        [Test]
        public void CheckValidProductSize()
        {
            // Arrange
            RequestAddProduct request = new()
            {
                Name = "Lenovo Thinkpad L13",
                ProductTypeId = 1,
                SKU = "100",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce condimentum purus id nibh varius, in pulvinar odio dapibus. Vivamus volutpat non lacus sed tristique. ",
                Weight = 4,
                XSize = 0,
                YSize = 2,
                ZSize = 1,
                Price = 1000,
            };

            // Act
            var result = _service.AddProduct(request);
            
            // Assert
            Assert.IsTrue(result.Messsage == ErrorsEnum.SIZE_NOT_VALID);
        }
       
    }
}