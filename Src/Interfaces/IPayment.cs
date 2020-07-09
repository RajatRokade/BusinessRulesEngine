using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /// <summary>
    /// Interface to Handle the Payment Related activities
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Type of the Payment
        /// </summary>
        string PaymentType { get;}

        /// <summary>
        /// Number of Rules Processed for a given payment
        /// </summary>
        int NumberOfRulesProcessed { get;}

        /// <summary>
        /// Register a new payment
        /// </summary>
        /// <param name="amount">Amount incurred during the transcation</param>
        /// <param name="rules">List of Rules to be Applied for post payment processing</param>
        void RegisterPayment(int amount, List<IPaymentRules> rules);

        /// <summary>
        /// Processing of the payment. This includes applying all the rules set
        /// </summary>
        void ProcessPayment();
    }
}
