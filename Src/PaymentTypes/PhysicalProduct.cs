using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.PaymentTypes
{
    public class PhysicalProduct : IPayment
    {
        public string PaymentType { get; set; }

        private List<IPaymentRules> rules = null; 

        public PhysicalProduct()
        {
            PaymentType = "PhysicalProduct";
        }
        public void RegisterPayment(int amount, List<IPaymentRules> rules)
        {
            Console.WriteLine("Payment of {0} recieved for {1}",amount,PaymentType);
            this.rules = rules; 
        }

        public void ProcessPayment()
        {
            foreach (var rule in rules)
            {
                Console.WriteLine("Applying {0} payment rule", rule.RuleName);
                rule.PerformAction();
            }
        }
    }
}
