using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    public interface IPayment
    {
        string PaymentType { get; set; }
        int NumberOfRulesProcessed { get;}
        void RegisterPayment(int amount, List<IPaymentRules> rules);
        void ProcessPayment();
    }
}
