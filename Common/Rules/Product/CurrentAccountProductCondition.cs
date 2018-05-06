
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class CurrentAccountProductCondition : Condition
    {
        public CurrentAccountProductCondition()
        {
            Id = 1;
            Name = "Current Account Rules";
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
