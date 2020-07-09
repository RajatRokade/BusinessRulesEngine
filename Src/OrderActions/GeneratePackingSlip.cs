using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    /// <summary>
    /// Department for which packing slip has to be generated
    /// </summary>
    public enum EDepratment
    {
        UNKNOWN = 0,
        SHIPPING = 1,
        ROYALTY = 2,
        VIDEO = 3
    };

    /// <summary>
    /// Class to handle the packing slip generation
    /// </summary>
    public class GeneratePackingSlip : IPaymentRules
    {
        /// <summary>
        /// Department Type
        /// </summary>
        private EDepratment generationType = EDepratment.UNKNOWN;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="type"></param>
        public GeneratePackingSlip(EDepratment type)
        {
            RuleName = "GeneratePackingSlip";
            generationType = type;
        }

        /// <summary>
        /// Inherited from the interfce
        /// </summary>
        public string RuleName { get; set; }

        /// <summary>
        /// Inherited from the interfce
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Generating Packing Slip for {0}",generationType.ToString());
        }
    }
}
