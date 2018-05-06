
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules
{
    public class GoldBundleCondition : Condition
    {
        public GoldBundleCondition()
        {
            Id = 5;
            Name = "Gold Credit Card Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age > 17))
            {
                yield return new RuleError() { ErrorMessage = "Invalid age", Code = "Age" };
            }

            if (!(answer.Income > 40000))
            {
                yield return new RuleError() { ErrorMessage = "Invalid income", Code = "Income" };
            }
        }
    }
}
