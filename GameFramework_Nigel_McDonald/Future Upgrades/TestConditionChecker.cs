using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class TestConditionChecker
    {
        private List<ITestConditionChecker> conditionCheckers;

        public TestConditionChecker(List<ITestConditionChecker> conditionCheckers)
        {
            this.conditionCheckers = conditionCheckers;
        }

        public bool CheckAllConditions(Game game)
        {
            foreach (var checker in conditionCheckers)
            {
                if (!checker.CheckConditions(game))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
