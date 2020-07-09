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
        static ProcessPayment payment = new ProcessPayment();
        static void Main(string[] args)
        {
            payment.Process(100,new PhysicalProduct());

            payment.FinalizePayments();

            Console.ReadLine();
        }
    }
}
