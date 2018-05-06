
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Bundle
{
    public class StudentBundleCondition : Condition
    {
        public StudentBundleCondition()
        {
            Id = 2;
            Name = "Student Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!answer.Student)
            {
                yield return new RuleError() { ErrorMessage = "Not Student", Code = "Student" };
            }

            if (!(answer.Age > 17))
            {
                yield return new RuleError() { ErrorMessage = "Age is not greater than 17", Code = "Age" };
            }
        }
    }
}
