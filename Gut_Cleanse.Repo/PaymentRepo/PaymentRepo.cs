using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Repo.PaymentRepo
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepo(ApplicationDbContext context) {
        _context = context;
        }
        public bool CreatePayment(PaymentModel payment)
        {
            try
            {
                var entity = payment.AutoMap<Payment>();
                entity.CreatedDateTime = DateTime.Now;
                entity.ModifyDateTime = null;
                _context.Add<Payment>(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



     public IEnumerable<PaymentModel> GetPaymentDetailByProgramId(int userId)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var result = (from payments in _context.Payments
                          join programs in _context.Programs
                          on payments.ProgramId equals programs.Id 
                          where payments.UserId == userId && payments.Status == 1
                          select new PaymentModel
                          {
                              Id = payments.Id,
                              ProgramName = programs.Name,
                              ProgramDescription = programs.Description,
                              StartDate = programs.StartDate,
                              EndDate = programs.EndDate,
                              Amount = payments.Amount,
                              Status = payments.Status,
                              UserId = userId,
                              IsActive = (programs.StartDate != null && programs.EndDate != null) &&(programs.StartDate <= currentDate) &&  (programs.EndDate >= currentDate)
                          }).ToList();

            return result;
        }

        public bool UpdatePayment(PaymentModel payment)
        {
            try
            {
                var entity = _context.Payments.FirstOrDefault(x => x.OrderId == payment.OrderId);
                if(entity != null)
                {
                    entity.ModifyDateTime = DateTime.UtcNow;
                    entity.PaymentId = payment.PaymentId;
                    entity.Status = payment.Status;
                    _context.Update<Payment>(entity);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception();
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
