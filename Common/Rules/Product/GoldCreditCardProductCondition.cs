
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class GoldCreditCardProductCondition : Condition
    {
        public GoldCreditCardProductCondition()
        {
            Id = 7;
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
