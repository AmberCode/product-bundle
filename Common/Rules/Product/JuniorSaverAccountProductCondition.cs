
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class JuniorSaverAccountProductCondition : Condition
    {
        public JuniorSaverAccountProductCondition()
        {
            Id = 3;
            Name = "Junior Saver Account Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!(answer.Age < 18))
            {
                yield return new RuleError() { ErrorMessage = "Invalid age", Code = "Age" };
            }
        }
    }
}
