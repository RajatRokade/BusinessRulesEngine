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
    public class ProcessPayment
    {
        public List<IPayment> paymentslist = new List<IPayment>();

        /// <summary>
        /// Method to process all the payments
        /// </summary>
        /// <param name="transcationAmount"></param>
        /// <param name="payment"></param>
        public void Process(int transcationAmount, IPayment payment)
        {
            if(payment.PaymentType == "PhysicalProduct")
            {
                ProcessPhysicalProduct(transcationAmount, payment);
            }
            else if(payment.PaymentType == "Book")
            {
                ProcessBookPayment(transcationAmount, payment);
            }
            else if (payment.PaymentType == "Video")
            {
                ProcessVideoPayment(transcationAmount, payment);
            }
            else if (payment.PaymentType == "Membership")
            {
                ProcessMembershipPayment(transcationAmount, payment);
            }
        }

        /// <summary>
        /// Method to consolidate all the payments and all take action on all the rules being set
        /// </summary>
        public void FinalizePayments()
        {
            foreach (var payment in paymentslist)
            {
                Console.WriteLine("Payment type is {0}", payment.PaymentType);
                payment.ProcessPayment();
            }
        }

        /// <summary>
        /// Method to process the physical product payment being made
        /// </summary>
        /// <param name="transcationAmount"></param>
        /// <param name="payment"></param>
        private void ProcessPhysicalProduct(int transcationAmount, IPayment payment)
        {
            payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                {
                    new GeneratePackingSlip(EDepratment.SHIPPING),
                    new CommisionPayment()
                });

            paymentslist.Add(payment);
        }

        /// <summary>
        /// Method to process the vibook payment being made
        /// </summary>
        /// <param name="transcationAmount"></param>
        /// <param name="payment"></param>
        private void ProcessBookPayment(int transcationAmount, IPayment payment)
        {
            payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                {
                    new GeneratePackingSlip(EDepratment.ROYALTY),
                    new CommisionPayment()
                });

            paymentslist.Add(payment);
        }

        /// <summary>
        /// Method to process the membership payment being made
        /// </summary>
        /// <param name="transcationAmount"></param>
        /// <param name="payment"></param>
        private void ProcessMembershipPayment(int transcationAmount, IPayment payment)
        {
            var membership = (Membership)payment;
            if (membership.membershipAction == EMembershipType.NEW)
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new ActivateMembership(),
                        new SendEmail()
                    });
            }
            else if (membership.membershipAction == EMembershipType.UPGRADE)
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new UpgradeMembership(),
                        new SendEmail()
                    });
            }

            paymentslist.Add(payment);
        }

        /// <summary>
        /// Method to process the video payment being made
        /// </summary>
        /// <param name="transcationAmount"></param>
        /// <param name="payment"></param>
        private void ProcessVideoPayment(int transcationAmount, IPayment payment)
        {
            var video = (Video)payment;
            if (video.videoType == "Learning to ski")
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new GeneratePackingSlip(EDepratment.VIDEO),
                        new AddVideo("First Aid")
                    });
            }
            else
            {
                payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new GeneratePackingSlip(EDepratment.VIDEO),
                    });
            }

            paymentslist.Add(payment);
        }
    }
}
