using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class TestConditionCheckerFactory
    {
        public TestConditionChecker CreateTestConditionChecker(List<ITestConditionChecker> conditionCheckers)
        {
            return new TestConditionChecker(conditionCheckers);
        }
    }
}
