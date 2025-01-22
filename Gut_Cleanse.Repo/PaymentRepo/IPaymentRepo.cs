using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Repo.PaymentRepo
{
    public interface IPaymentRepo
    {
        bool CreatePayment(PaymentModel payment);
        bool UpdatePayment(PaymentModel payment);
    }
}
