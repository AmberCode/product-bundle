
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules
{
    public class PensionerBundleCondition : Condition
    {
        public PensionerBundleCondition()
        {
            Id = 6;
            Name = "Pensioner Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age > 64))
            {
                yield return new RuleError() { ErrorMessage = "Not Pensioner ", Code = "Age" };
            }
        }
    }
}
