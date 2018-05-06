
using System.Collections.Generic;

namespace Common.Models
{
    public class BundleConfigModel
    {       
        public int BundleId { get; set; }
        public IEnumerable<int> ProductId { get; set; }
        public int RuleId { get; set; }
        public int Value { get; set; }
    }
}
