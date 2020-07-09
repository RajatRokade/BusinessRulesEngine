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
        public List<IPayment> paymentslist = new List<IPayment>();

        public void Process(int transcationAmount, IPayment payment)
        {
            if(payment.PaymentType == "PhysicalProduct")
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                {
                    new GeneratePackingSlip(EDepratment.SHIPPING),
                    new CommisionPayment()
                });

                paymentslist.Add(payment);
            }
            else if(payment.PaymentType == "Book")
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                {
                    new GeneratePackingSlip(EDepratment.ROYALTY),
                    new CommisionPayment()
                });

                paymentslist.Add(payment);
            }
        }

        public void FinalizePayments()
        {
            foreach (var payment in paymentslist)
            {
                Console.WriteLine("Payment type is {0}", payment.PaymentType);
                payment.ProcessPayment();
            }
        }
    }
}
