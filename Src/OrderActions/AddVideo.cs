using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.OrderActions
{
    public class AddVideo : IPaymentRules
    {
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public string RuleName { get; private set; } = "Add Video";

        /// <summary>
        /// Name of the video to be added
        /// </summary>
        private string VideoName;

        public AddVideo(string VideoName)
        {
            this.VideoName = VideoName;
        }
        /// <summary>
        /// Inherited from the Interface
        /// </summary>
        public void ApplyRules()
        {
            Console.WriteLine("Adding video to the packing slip of type {0}",VideoName);
        }
    }
}
