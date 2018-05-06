using Common.Models;
using System.Collections.Generic;

namespace Common.Interfaces.Repository
{
    /// <summary>
    /// Product context
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel Get(int id);
        IEnumerable<ProductConfigModel> GetAllProductConfigs();
    }
}
