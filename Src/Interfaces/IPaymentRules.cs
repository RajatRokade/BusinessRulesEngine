using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine
{
    /// <summary>
    /// Interface to handle rules
    /// </summary>
    public interface IPaymentRules
    {
        /// <summary>
        /// Name of the rule
        /// </summary>
        string RuleName { get; }

        /// <summary>
        /// Apply the rule to process the payment
        /// </summary>
        void ApplyRules();
    }
}
