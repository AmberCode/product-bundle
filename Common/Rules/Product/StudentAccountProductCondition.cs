
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules.Product
{
    public class StudentAccountProductCondition : Condition
    {
        public StudentAccountProductCondition()
        {
            Id = 4;
            Name = "Student Account Rules";
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
