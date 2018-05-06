using Common.Models;
using Common.ViewModels;
using System.Collections.Generic;

namespace Common.Interfaces.Service
{
    /// <summary>
    /// Bundle related concerns
    /// </summary>
    public interface IBundleService
    {
        IEnumerable<BundleModel> GetAll();
        IEnumerable<BundleConfigModel> GetBundleConfigs();
        BundleViewModel GetRecommendedBundle(AnswerModel answer);
        BundleViewModel DeleteProduct(AnswerModel answer, int bundleId, int productId);
        BundleViewModel AddProduct(AnswerModel answer, int bundleId, int productId);
    }
}
