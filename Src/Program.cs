using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.OrderActions;
using BusinessRulesEngine.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPayment> payments = new List<IPayment>();

            var physicalProductPayment = new PhysicalProduct();
            // Registering Payment with 2 rules
            physicalProductPayment.RegisterPayment(100, new List<IPaymentRules>()
            {
                new GeneratePackingSlip(EDepratment.SHIPPING),
                new CommisionPayment()
            }) ;

            payments.Add(physicalProductPayment);

            //Execute All Payments 

            foreach(var payment in payments)
            {
                Console.WriteLine("Payment type is {0}",payment.PaymentType);
                payment.ProcessPayment();
            }

            Console.ReadLine();
        }
    }
}
