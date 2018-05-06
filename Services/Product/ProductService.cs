
using System.Collections.Generic;
using Common.Models;
using Repositories;
using Common.Factories;
using System.Linq;
using Common.Rules;
using Common.Interfaces.Service;
using Common.ViewModels;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        //TODO: Dependency injection
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public ProductModel Get(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _productRepository.GetAllProducts();
        }

        public ProductViewModel GetProducts(AnswerModel answer)
        {
            var list = _productRepository.GetAllProductConfigs();

            var validList = new List<ProductModel>();

            foreach (var x in list)
            {
                var errors = new List<RuleError>();

                foreach(var r in x.RuleId)
                {                   
                    var er = ProductConditionFactory.Get(r).IsValid(answer);

                    if (er.Count() > 0)
                    {
                        errors.AddRange(er);
                    }
                }

                if (errors.Count() == 0)
                {
                    validList.Add(_productRepository.Get(x.ProductId));
                }
            }

            if (validList.Count > 0)
            {
                return new ProductViewModel
                {
                    Success = true,
                    Products = validList
                };
            }

            return new ProductViewModel
            {
                Success = false,
                Errors = new List<string> { "Not found by given criterion"}
            };
        }
    }
}
