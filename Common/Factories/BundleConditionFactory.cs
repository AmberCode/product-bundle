
using Common.Rules;
using Common.Rules.Bundle;
using System;

namespace Common.Factories
{
    public class BundleConditionFactory
    {
        //TODO: DI or some rule engine
        public static Condition Get(int id)
        {
            switch(id)
            {
                case 1:
                    return new JuniorBundleCondition();
                case 2:
                    return new StudentBundleCondition();
                case 3:
                    return new ClassicBundleCondition();
                case 4:
                    return new ClassicPlusBundleCondition();
                case 5:
                    return new GoldBundleCondition();
                case 6:
                    return new PensionerBundleCondition();
                case 7:
                    return new DebitCardCondition();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
