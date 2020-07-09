using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    /// <summary>
    /// Comminsion Payment management class
    /// </summary>
    public class CommisionPayment : IPaymentRules
    {
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public string RuleName { get; private set; } = "Commision Payment";

        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Generating Commision Payment to Agent");
        }
    }
}
