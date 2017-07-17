using DataAccess.Repositories.Interfaces;
using Logic.Services;
using Models.Entities;
using Models.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myRetail.Tests
{
    [TestFixture]
    public class ProductServiceTest
    {
        private ProductEntity _product;
        private List<ProductEntity> _products;

        [SetUp]
        public void Init()
        {
            _product = new ProductEntity
            {
                Price = 199.99M,
                Id = 2,
                CategoryTypeId = CategoryType.Baby,
                Name = "Stroller",
                LastUpdated = DateTime.Now,
                Sku = "xds97s"
            };

            _products = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Price = 199.99M,
                    Id = 2,
                    CategoryTypeId = CategoryType.Baby,
                    Name = "Stroller",
                    LastUpdated = DateTime.Now,
                    Sku = "xds97s"
                },
                new ProductEntity
                {
                    Price = 129.99M,
                    Id = 1,
                    CategoryTypeId = CategoryType.Toys,
                    Name = "Sega Genesis",
                    LastUpdated = DateTime.Now,
                    Sku = "eoir832"
                }
            };
        }

        [TestCase(2, "Stroller")]
        public async Task GetProductTest(long id, string expected)
        {
            //Arrange
            var mockRepo = new Mock<IProductApiRepository>();
            mockRepo.Setup(x => x.GetProduct(id)).Returns(Task.FromResult(_product));
            var mockService = new ProductApiService(mockRepo.Object);

            //Act
            var actual = await mockService.GetProduct(id);

            //Assert
            Assert.AreEqual(expected, actual.Name);
        }

        [TestCase(2)]
        public async Task GetProductsTest(int expected)
        {
            //Arrange
            var mockRepo = new Mock<IProductApiRepository>();
            mockRepo.Setup(x => x.GetProducts()).Returns(Task.FromResult(_products));
            var mockService = new ProductApiService(mockRepo.Object);

            //Act
            var actual = await mockService.GetProducts();

            //Assert
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
