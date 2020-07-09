using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    public enum EDepratment
    {
        UNKNOWN = 0,
        SHIPPING = 1,
        ROYALTY = 2
    };

    public class GeneratePackingSlip : IPaymentRules
    {
        
        private EDepratment generationType = EDepratment.UNKNOWN;
        public GeneratePackingSlip(EDepratment type)
        {
            RuleName = "GeneratePackingSlip";
            generationType = type;
        }

        public string RuleName { get; set; }

        public void PerformAction()
        {
            Console.WriteLine("Generating Packing Slip for {0}",generationType.ToString());
        }
    }
}
