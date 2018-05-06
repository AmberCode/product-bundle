using Common.Models;
using Services.Bundle;
using Xunit;
using Services.Product;

namespace UnitTests
{
    
    public class BundleUnitTests
    {
        [Fact]
        public void GetJuniorBundle_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 15,
                Student = false,
                Income = 0
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);
            
            Assert.True(result.Success && result.Bundle.Id == 1 && result.Products.Count == 1);
        }

        [Fact]
        public void GetJuniorBundle_Fail()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 0
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success == false);
        }

        [Fact]
        public void GetStudentBundle_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = true,
                Income = 0
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 2 && result.Products.Count == 3);
        }

        [Fact]
        public void GetClassicBundle_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 1
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 3 && result.Products.Count == 2);
        }

        [Fact]
        public void GetClassicBundle_IsStudentTrue_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = true,
                Income = 1
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 3 && result.Products.Count == 2);
        }

        [Fact]
        public void GetClassicPlusBundle_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 12001
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 4 && result.Products.Count == 3);
        }

        [Fact]
        public void GetGoldBundle_Ok()
        {
            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 40001
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 5 && result.Products.Count == 3);
        }

        [Fact]
        public void GetGoldBundle_Fail()
        {
            var answer = new AnswerModel()
            {
                Age = 17,
                Student = false,
                Income = 50000
            };
            var bundleService = new BundleService();

            var result = bundleService.GetRecommendedBundle(answer);

            Assert.True(result.Success && result.Bundle.Id == 1 && result.Products.Count == 1);
        }

        [Fact]
        public void RemoveProductFromBundle_Ok()
        {
            var bundleService = new BundleService();
            var productService = new ProductService();

            var bundleConfigs = bundleService.GetBundleConfigs();

            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 12001
            };

            var removeProduct = productService.Get(6);
            var classicPlusBundle = bundleService.GetRecommendedBundle(answer);

            var result = bundleService.DeleteProduct(answer, classicPlusBundle.Bundle.Id, removeProduct.Id);
                       
            Assert.True(result.Success && result.Bundle.Id == 3);
        }

        [Fact]
        public void AddProductOnBundle_Fail()
        {
            var bundleService = new BundleService();
            var productService = new ProductService();

            var bundleConfigs = bundleService.GetBundleConfigs();

            var answer = new AnswerModel()
            {
                Age = 18,
                Student = false,
                Income = 1
            };

            var addProduct = productService.Get(6);

            var classicBundle = bundleService.GetRecommendedBundle(answer);

            var result = bundleService.AddProduct(answer, classicBundle.Bundle.Id, addProduct.Id);

            Assert.True(!result.Success);
        }
    }
}
