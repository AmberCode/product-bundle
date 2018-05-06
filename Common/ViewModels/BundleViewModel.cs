using Common.Models;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class BundleViewModel
    {
        public BundleViewModel()
        {
            Products = new List<ProductModel>();
        }
        public BundleModel Bundle { get; set; }
        public List<ProductModel> Products { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
