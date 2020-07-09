using System;
using BusinessRulesEngine.PaymentTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRulesEngine.Tests
{
    [TestClass]
    public class NumberOfRulesTest
    {
        [TestMethod]
        public void PhysicalProduct_Applied_Rules_Check()
        {
            ProcessPayment payment = new ProcessPayment();

            payment.Process(100, new PhysicalProduct());
            Assert.AreEqual(0, payment.paymentslist[0].NumberOfRulesProcessed);
            payment.FinalizePayments();
            Assert.AreEqual(2, payment.paymentslist[0].NumberOfRulesProcessed);
        }

        public void Book_Applied_Rules_Check()
        {
            ProcessPayment payment = new ProcessPayment();

            payment.Process(100, new Book());
            Assert.AreEqual(0, payment.paymentslist[0].NumberOfRulesProcessed);
            payment.FinalizePayments();
            Assert.AreEqual(2, payment.paymentslist[0].NumberOfRulesProcessed);
        }
    }
}
