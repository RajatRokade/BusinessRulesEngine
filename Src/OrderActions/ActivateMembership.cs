using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    /// <summary>
    /// Class to handle the rule to handle the activation of membership
    /// </summary>
    public class ActivateMembership : IPaymentRules
    {
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public string RuleName { get; private set; } = "Activate Membership";

        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Activate Membership performed");
        }
    }
}
