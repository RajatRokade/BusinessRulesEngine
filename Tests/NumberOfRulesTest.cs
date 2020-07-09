using System;
using BusinessRulesEngine.OrderActions;
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

        [TestMethod]
        public void Book_Applied_Rules_Check()
        {
            ProcessPayment payment = new ProcessPayment();

            payment.Process(100, new Book());
            Assert.AreEqual(0, payment.paymentslist[0].NumberOfRulesProcessed);
            payment.FinalizePayments();
            Assert.AreEqual(2, payment.paymentslist[0].NumberOfRulesProcessed);
        }

        [TestMethod]
        public void Membership_Applied_Rules_Check()
        {
            ProcessPayment payment = new ProcessPayment();

            payment.Process(100, new Membership(EMembershipType.NEW));
            payment.Process(100, new Membership(EMembershipType.UPGRADE));
            Assert.AreEqual(0, payment.paymentslist[0].NumberOfRulesProcessed);
            payment.FinalizePayments();
            Assert.AreEqual(2, payment.paymentslist[0].NumberOfRulesProcessed);
            Assert.AreEqual(2, payment.paymentslist[1].NumberOfRulesProcessed);
        }

        [TestMethod]
        public void Video_Rules_Check()
        {
            ProcessPayment payment = new ProcessPayment();

            payment.Process(100, new Video("Learning to ski"));
            Assert.AreEqual(0, payment.paymentslist[0].NumberOfRulesProcessed);
            payment.FinalizePayments();
            Assert.AreEqual(2, payment.paymentslist[0].NumberOfRulesProcessed);

            payment.Process(100, new Video());
            payment.FinalizePayments();
            Assert.AreEqual(1, payment.paymentslist[1].NumberOfRulesProcessed);

        }
    }
}
