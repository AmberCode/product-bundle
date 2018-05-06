using Common.Models;
using Services.Product;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class ProductUnitTests
    {
        [Fact]
        public void GetProductsAll_Ok()
        {
            var productService = new ProductService();

            var result = productService.GetAll();

            Assert.True(result?.Count() > 0);
        }

        [Fact]
        public void GetProducts_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 17,
                Student = false,
                Income = 0
            };

            var productService = new ProductService();

            var result = productService.GetProducts(answer);

            Assert.True(result.Success && result.Products.First().Id == 3);
        }

        [Fact]
        public void GetProducts_Fail()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 0
            };

            var productService = new ProductService();

            var result = productService.GetProducts(answer);

            Assert.True(!result.Success);
        }
    }
}
