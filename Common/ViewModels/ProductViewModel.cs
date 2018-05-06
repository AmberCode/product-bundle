
using Common.Models;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
