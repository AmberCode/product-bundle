using Common.Models;
using System.Collections.Generic;

namespace Common.Rules
{
    public class ClassicBundleCondition : Condition
    {
        public ClassicBundleCondition()
        {
            Id = 3;
            Name = "Classic Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age > 17))
            {
                yield return new RuleError() { ErrorMessage = "Invalid age", Code = "Age" };
            }

            if (!(answer.Income > 0))
            {
                yield return new RuleError() { ErrorMessage = "Invalid income", Code = "Income" };
            }
        }
    }
}
