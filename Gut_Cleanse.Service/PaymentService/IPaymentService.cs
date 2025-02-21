using Gut_Cleanse.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.PaymentService
{
    public interface IPaymentService
    {
        bool CreatePayment(PaymentModel payment);
        bool UpdatePayment(PaymentModel payment);
        IEnumerable<PaymentModel> GetPaymentDetailByProgramId(int userId);
    }
}
