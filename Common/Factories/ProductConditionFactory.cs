using Common.Rules;
using Common.Rules.Product;
using System;

namespace Common.Factories
{
    //TODO: DI or some rule engine
    public class ProductConditionFactory
    {
        public static Condition Get(int id)
        {
            switch (id)
            {
                case 1:
                    return new CurrentAccountProductCondition();
                case 2:
                    return new CurrentAccountPlusProductCondition();
                case 3:
                    return new JuniorSaverAccountProductCondition();
                case 4:
                    return new StudentAccountProductCondition();
                case 5:
                    return new DebitCardProductCondition();
                case 6:
                    return new CreditCardProductCondition();
                case 7:
                    return new GoldCreditCardProductCondition();
                case 8:
                    return new PensionerProductCondition();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
