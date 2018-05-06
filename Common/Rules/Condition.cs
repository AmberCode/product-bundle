
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules
{
    public abstract class Condition : ICondition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract IEnumerable<RuleError> IsValid(AnswerModel answer);
    }
}
