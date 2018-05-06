
using Common.Interfaces.Repository;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductModel> GetAllProducts()
        {
            var productDbTable = new StringBuilder();
            productDbTable.Append("[");
            productDbTable.Append("{\"Id\":1,\"ProductName\":\"Current Account\"},");
            productDbTable.Append("{\"Id\":2,\"ProductName\":\"Current Account Plus\"},");
            productDbTable.Append("{\"Id\":3,\"ProductName\":\"Junior Saver Account\"},");
            productDbTable.Append("{\"Id\":4,\"ProductName\":\"Student Account\"},");
            productDbTable.Append("{\"Id\":5,\"ProductName\":\"Debit Card\"},");
            productDbTable.Append("{\"Id\":6,\"ProductName\":\"Credit Card\"},");
            productDbTable.Append("{\"Id\":7,\"ProductName\":\"Gold Credit Card\"},");
            productDbTable.Append("{\"Id\":8,\"ProductName\":\"Pensioner Account\"}");
            productDbTable.Append("]");

            return new JavaScriptSerializer().Deserialize<List<ProductModel>>(productDbTable.ToString());
        }

        public ProductModel Get(int id)
        {
            return GetAllProducts().First(x => x.Id == id);
        }

        public IEnumerable<ProductConfigModel> GetAllProductConfigs()
        {
            var productConfigDbTable = new StringBuilder();
            productConfigDbTable.Append("[");
            productConfigDbTable.Append("{\"ProductId\":1,\"RuleId\":[1]},");
            productConfigDbTable.Append("{\"ProductId\":2,\"RuleId\":[2]},");
            productConfigDbTable.Append("{\"ProductId\":3,\"RuleId\":[3]},");
            productConfigDbTable.Append("{\"ProductId\":4,\"RuleId\":[4]},");
            productConfigDbTable.Append("{\"ProductId\":5,\"RuleId\":[5]},");
            productConfigDbTable.Append("{\"ProductId\":6,\"RuleId\":[6]},");
            productConfigDbTable.Append("{\"ProductId\":7,\"RuleId\":[7]},");
            productConfigDbTable.Append("{\"ProductId\":8,\"RuleId\":[8]}");
            productConfigDbTable.Append("]");

            return new JavaScriptSerializer().Deserialize<List<ProductConfigModel>>(productConfigDbTable.ToString());
        }
    }
}
