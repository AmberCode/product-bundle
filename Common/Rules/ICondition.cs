using Common.Models;
using System.Collections.Generic;

namespace Common.Rules
{
    public interface ICondition
    {
        IEnumerable<RuleError> IsValid(AnswerModel answer);
    }
}
