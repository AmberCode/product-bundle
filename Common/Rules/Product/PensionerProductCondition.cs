
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class PensionerProductCondition : Condition
    {
        public PensionerProductCondition()
        {
            Id = 8;
            Name = "Pensioner Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age > 65))
            {
                yield return new RuleError() { ErrorMessage = "Invalid age", Code = "Age" };
            }
        }
    }
}
