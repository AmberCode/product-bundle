using Common.Models;
using Common.ViewModels;
using System.Collections.Generic;

namespace Common.Interfaces.Service
{
    /// <summary>
    /// Product related concerns
    /// </summary>
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Get(int id);
        ProductViewModel GetProducts(AnswerModel answer);
    }
}
