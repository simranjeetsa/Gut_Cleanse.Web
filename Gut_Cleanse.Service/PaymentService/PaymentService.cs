using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.PaymentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _paymentRepo;
        public PaymentService(IPaymentRepo paymentRepo) {
        _paymentRepo = paymentRepo;
        }
        public bool CreatePayment(PaymentModel payment)
        {
            return _paymentRepo.CreatePayment(payment);
        }

        public IEnumerable<PaymentModel> GetPaymentDetailByProgramId(int userId)
        {
            return _paymentRepo.GetPaymentDetailByProgramId(userId);
        }

        public bool UpdatePayment(PaymentModel payment)
        {
            return _paymentRepo.UpdatePayment(payment);
        }
    }
}
