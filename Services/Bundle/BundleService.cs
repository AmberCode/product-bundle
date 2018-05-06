
using System.Collections.Generic;
using Common.Models;
using Repositories;
using System.Linq;
using Common.Factories;
using Common.Interfaces.Service;
using Common.ViewModels;

namespace Services.Bundle
{
    public class BundleService : IBundleService
    {
        //TODO: DI
        private readonly BundleRepository _bundleRepository;
        private readonly ProductRepository _productRepository;

        public BundleService()
        {
            _bundleRepository = new BundleRepository();
            _productRepository = new ProductRepository();
        }

        public BundleViewModel AddProduct(AnswerModel answer, int bundleId, int productId)
        {
            var bundleConfigs = _bundleRepository.GetAllBundleConfigs();

            var currentBundle = _bundleRepository.GetBundleConfig(bundleId);

            if (currentBundle.ProductId.Contains(productId))
            {
                return new BundleViewModel
                {
                    Success = false,
                    Errors = new List<string> { "Already contains product" }
                };
            }
            
            var proposalProducts = new List<int>();

            proposalProducts.AddRange(currentBundle.ProductId);
            proposalProducts.Add(productId);

            var proposalBundles =
                bundleConfigs.Where(x => !x.ProductId.Except(proposalProducts)
                .Union(proposalProducts.Except(x.ProductId)).Any()).ToList();


            if (proposalBundles.Count == 0)
            {
                return new BundleViewModel
                {
                    Success = false,
                    Errors = new List<string> { "Couldn't find any bundle by given products" }
                };
            }

            return GetRecommendedBundle(proposalBundles, answer);
        }

        public BundleViewModel DeleteProduct(AnswerModel answer, int bundleId, int productId)
        {      
            var bundleConfigs = _bundleRepository.GetAllBundleConfigs();

            var currentBundle = _bundleRepository.GetBundleConfig(bundleId);

            var proposalProducts = currentBundle.ProductId.Where(x => x != productId).ToList();

            var proposalBundles =
                bundleConfigs.Where(x => !x.ProductId.Except(proposalProducts)
                .Union(proposalProducts.Except(x.ProductId)).Any()).ToList();

            if (proposalBundles.Count == 0)
            {
                return new BundleViewModel
                {
                    Success = false,
                    Errors = new List<string> { "Not found by given products" }
                };
            }
            
            return GetRecommendedBundle(proposalBundles, answer);
        }

        public IEnumerable<BundleModel> GetAll()
        {
            return _bundleRepository.GetAllBundles();
        }

        public IEnumerable<BundleConfigModel> GetBundleConfigs()
        {
            return _bundleRepository.GetAllBundleConfigs();
        }

        public BundleViewModel GetRecommendedBundle(AnswerModel answer)
        {
            return GetRecommendedBundle(_bundleRepository.GetAllBundleConfigs(), answer);
        }

        public BundleViewModel GetRecommendedBundle(IEnumerable<BundleConfigModel> bundles, AnswerModel answer)
        {
            var validList = new List<BundleConfigModel>();

            foreach (var x in bundles)
            {
                if (BundleConditionFactory.Get(x.RuleId).IsValid(answer).Count() == 0)
                {
                    validList.Add(x);
                }
            }

            if (validList.Count > 0)
            {
                var recommended = validList.OrderByDescending(x => x.Value).First();

                var viewModel = new BundleViewModel()
                {
                    Success = true,
                    Bundle = _bundleRepository.GetBundle(recommended.BundleId)
                };

                foreach (var b in recommended.ProductId)
                {
                    viewModel.Products.Add(_productRepository.Get(b));
                }

                return viewModel;
            }

            var errorViewModel = new BundleViewModel()
            {
                Success = false,
                Errors = new List<string>
                {
                   "Not found by given answer"
                }
            };

            return errorViewModel;
        }
    }
}
