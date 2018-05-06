
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules
{
    public class JuniorBundleCondition : Condition
    {
        public JuniorBundleCondition()
        {
            Id = 1;
            Name = "Junior Saver Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age < 18))
            {
                yield return new RuleError() { ErrorMessage = "Not Junior", Code = "Age" };
            }
        }
    }
}
