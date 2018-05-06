using Common.Interfaces.Repository;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Repositories
{
    public class BundleRepository : IBundleRepository
    {
        public IEnumerable<BundleModel> GetAllBundles()
        {
            var bundleDbTable = new StringBuilder();
            bundleDbTable.Append("[");
            bundleDbTable.Append("{\"Id\":1,\"BundleName\":\"Junior Saver\",\"Value\":0},");
            bundleDbTable.Append("{\"Id\":2,\"BundleName\":\"Student\",\"Value\":0},");
            bundleDbTable.Append("{\"Id\":3,\"BundleName\":\"Classic\",\"Value\":0},");
            bundleDbTable.Append("{\"Id\":4,\"BundleName\":\"Classic Plus\",\"Value\":0},");
            bundleDbTable.Append("{\"Id\":5,\"BundleName\":\"Gold\",\"Value\":0},");
            bundleDbTable.Append("{\"Id\":6,\"BundleName\":\"Pensioner\",\"Value\":0}");
            bundleDbTable.Append("]");

            return new JavaScriptSerializer().Deserialize<List<BundleModel>>(bundleDbTable.ToString());
        }

        public BundleModel GetBundle(int id)
        {
            return GetAllBundles().First(x => x.Id == id);
        }

        public BundleConfigModel GetBundleConfig(int bundleId)
        {
            return GetAllBundleConfigs().First(x => x.BundleId == bundleId);
        }

        public IEnumerable<BundleConfigModel> GetAllBundleConfigs()
        {
            var bundleConfigDbTable = new StringBuilder();
            bundleConfigDbTable.Append("[{\"BundleId\":1,\"ProductId\":[3],\"RuleId\":1,\"Value\":0},");
            bundleConfigDbTable.Append("{\"BundleId\":2,\"ProductId\":[4,5,6],\"RuleId\":2,\"Value\":0},");
            bundleConfigDbTable.Append("{\"BundleId\":3,\"ProductId\":[1,5],\"RuleId\":3,\"Value\":1},");
            bundleConfigDbTable.Append("{\"BundleId\":4,\"ProductId\":[1,5,6],\"RuleId\":4,\"Value\":2},");
            bundleConfigDbTable.Append("{\"BundleId\":5,\"ProductId\":[2,5,7],\"RuleId\":5,\"Value\":3},");
            bundleConfigDbTable.Append("{\"BundleId\":6,\"ProductId\":[8],\"RuleId\":6,\"Value\":0}");
            bundleConfigDbTable.Append("]");

            return new JavaScriptSerializer().Deserialize<List<BundleConfigModel>>(bundleConfigDbTable.ToString());
        }
    }
}
