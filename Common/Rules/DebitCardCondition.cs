﻿
using System.Collections.Generic;
using Common.Models;

namespace Common.Rules
{
    public class DebitCardCondition : Condition
    {
        public DebitCardCondition()
        {
            Id = 7;
            Name = "Debit Card Rules";
        }

        public override IEnumerable<RuleError> IsValid(AnswerModel answer)
        {
            if (!((answer.Age > 17 && answer.Income > 0) 
                || (answer.Age > 17 && answer.Income > 40000)
                || (answer.Student && answer.Age > 17)
                || (answer.Age > 64)))
            {
                yield return new RuleError() { ErrorMessage = "Invalid data", Code = "Debit" };
            }
        }
    }
}
