using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.PaymentTypes
{
    /// <summary>
    /// enum to perform membership operations
    /// </summary>
    public enum EMembershipType
    {
        UNKNOWN = 0,
        NEW = 1,
        UPGRADE = 2
    };

    /// <summary>
    /// Class to handle the membership related actions
    /// </summary>
    public class Membership : IPayment
    {
        /// <summary>
        /// Inherited from Interfce
        /// </summary>
        public string PaymentType { get; private set; }

        /// <summary>
        /// Inherited from Interfce
        /// </summary>
        public int NumberOfRulesProcessed { get; private set; } = 0;

        /// <summary>
        /// Type of membership action to be performed
        /// </summary>
        public EMembershipType membershipAction = EMembershipType.UNKNOWN;

        /// <summary>
        /// Number of rules which needs to be applied for the payment post processing
        /// </summary>
        private List<IPaymentRules> rules = null;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="type"></param>
        public Membership(EMembershipType type)
        {
            PaymentType = "Membership";
            membershipAction = type;
        }
        public void ProcessPayment()
        {
            foreach (var rule in rules)
            {
                NumberOfRulesProcessed++;
                Console.WriteLine("Applying {0} payment rule", rule.RuleName);
                rule.ApplyRules();
            }
        }

        public void RegisterPayment(int amount, List<IPaymentRules> rules)
        {
            Console.WriteLine("Payment of {0} recieved for {1}", amount, PaymentType);
            this.rules = rules;
        }
    }
}
