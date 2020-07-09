using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Tests.Rules
{
    class CustomRuleForTest : IPaymentRules
    {
        public string RuleName { get; } = "Extention_Test_Rule";

        public void ApplyRules()
        {
            Console.WriteLine("Executing Test Rule");
        }
    }
}
