using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessRulesEngine.Interfaces;
using BusinessRulesEngine.OrderActions;
using BusinessRulesEngine.PaymentTypes;
using BusinessRulesEngine.Tests.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRulesEngine.Tests
{
    /// <summary>
    /// Class to test the extensibility feature of adding on the fly new rules to any product
    /// </summary>
    [TestClass]
    public class RuleExtensionTest
    {
        [TestMethod]
        public void Add_Rules()
        {
            List<IPayment> paymentslist = new List<IPayment>();

            var newPayment = new PhysicalProduct();
            newPayment.RegisterPayment(100, new List<IPaymentRules>()
            {
                new GeneratePackingSlip(EDepratment.SHIPPING),
                new CommisionPayment(),
                //Adding the new rule on the fly
                new CustomRuleForTest()
            });

            paymentslist.Add(newPayment);

            foreach (var payment in paymentslist)
            {
                payment.ProcessPayment();
            }

            Assert.AreEqual(3, paymentslist[0].NumberOfRulesProcessed);
        }
    }
}
