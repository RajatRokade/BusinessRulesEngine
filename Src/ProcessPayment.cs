using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.OrderActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine
{
    public class ProcessPayment
    {
        List<IPayment> payments = new List<IPayment>();
        public void Process(int transcationAmount, IPayment payment)
        {
            if(payment.PaymentType == "PhysicalProduct")
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                {
                    new GeneratePackingSlip(EDepratment.SHIPPING),
                    new CommisionPayment()
                });

                payments.Add(payment);
            }
        }

        public void FinalizePayments()
        {
            foreach (var payment in payments)
            {
                Console.WriteLine("Payment type is {0}", payment.PaymentType);
                payment.ProcessPayment();
            }
        }
    }
}
