using Common.Models;
using System.Collections.Generic;

namespace Common.Rules
{
    public class ClassicPlusBundleCondition : Condition
    {
        public ClassicPlusBundleCondition()
        {
            Id = 4;
            Name = "Classic Plus Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age > 17))
            {
                yield return new RuleError() { ErrorMessage = "Invalid age", Code = "Age" };
            }

            if (!(answer.Income > 12000))
            {
                yield return new RuleError() { ErrorMessage = "Invalid income", Code = "Income" };
            }
        }
    }
}
