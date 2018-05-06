
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class CreditCardProductCondition : Condition
    {
        public CreditCardProductCondition()
        {
            Id = 6;
            Name = "Credit Card Rules";
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
