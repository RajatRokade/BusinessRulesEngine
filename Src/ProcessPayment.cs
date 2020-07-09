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
            else if (payment.PaymentType == "Video")
            {
                var video = (Video)payment;
                if(video.videoType == "Learning to ski")
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
            else if (payment.PaymentType == "Membership")
            {
                var membership = (Membership)payment;
                if (membership.membershipAction == EMembershipType.NEW)
                {
                    payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new ActivateMembership(),
                        new SendEmail()
                    }) ;
                }
                else if(membership.membershipAction == EMembershipType.UPGRADE)
                {
                    payment.RegisterPayment(transcationAmount, new List<IPaymentRules>()
                    {
                        new UpgradeMembership(),
                        new SendEmail()
                    });
                }

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
