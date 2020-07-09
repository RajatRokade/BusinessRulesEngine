using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.PaymentTypes
{
    /// <summary>
    /// Class to hanlde Physical Product purchase type
    /// </summary>
    public class PhysicalProduct : IPayment
    {
        /// <summary>
        /// Inherited from Interfce
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Inherited from Interfce
        /// </summary>
        public int NumberOfRulesProcessed { get; private set; } = 0;

        /// <summary>
        /// Number of rules which needs to be applied for the payment post processing
        /// </summary>
        private List<IPaymentRules> rules = null; 

        /// <summary>
        /// Ctor
        /// </summary>
        public PhysicalProduct()
        {
            PaymentType = "PhysicalProduct";
        }

        /// <summary>
        /// Inherited from Interface
        /// </summary>
        public void RegisterPayment(int amount, List<IPaymentRules> rules)
        {
            Console.WriteLine("Payment of {0} recieved for {1}",amount,PaymentType);
            this.rules = rules; 
        }

        /// <summary>
        /// Inherited from Interface
        /// </summary>
        public void ProcessPayment()
        {
            foreach (var rule in rules)
            {
                NumberOfRulesProcessed++;
                Console.WriteLine("Applying {0} payment rule", rule.RuleName);
                rule.ApplyRules();
            }
        }
    }
}
