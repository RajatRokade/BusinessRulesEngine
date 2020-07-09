using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    /// <summary>
    /// Class to handle the rule to handle the upgrading of membership
    /// </summary>
    public class UpgradeMembership : IPaymentRules
    {
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public string RuleName { get; private set; } = "Upgrade Membership";

        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Upgrading of membership performed");
        }
    }
}
