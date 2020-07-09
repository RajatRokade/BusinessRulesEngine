using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    /// <summary>
    /// Class to handle the rule to send an email communication
    /// </summary>
    public class SendEmail : IPaymentRules
    {
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public string RuleName { get; private set; } = "Send Email";

        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Sending Email to the Owner");
        }
    }
}
