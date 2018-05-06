using System.Collections.Generic;

namespace Common.Models
{
    public class ProductConfigModel
    {
        public int ProductId { get; set; }
        public IEnumerable<int> RuleId { get; set; }
    }
}
