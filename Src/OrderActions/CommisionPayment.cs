using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    public class CommisionPayment : IPaymentRules
    {
        public string RuleName { get; private set; } = "Commision Payment";

        public void ApplyRules()
        {
            Console.WriteLine("Generating Commision Payment to Agent");
        }
    }
}
