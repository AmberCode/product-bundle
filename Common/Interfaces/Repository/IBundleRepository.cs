using Common.Models;
using System.Collections.Generic;

namespace Common.Interfaces.Repository
{
    /// <summary>
    /// Bundle Context
    /// </summary>
    public interface IBundleRepository
    {
        IEnumerable<BundleModel> GetAllBundles();
        BundleModel GetBundle(int id);
        BundleConfigModel GetBundleConfig(int bundleId);
        IEnumerable<BundleConfigModel> GetAllBundleConfigs();
    }
}
