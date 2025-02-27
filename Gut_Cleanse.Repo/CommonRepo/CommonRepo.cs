using Gut_Cleanse.Common;
using Gut_Cleanse.Data;
using Gut_Cleanse.Model;
using System.Collections.Generic;

namespace Gut_Cleanse.Repo.Common
{
    public class CommonRepo : ICommonRepo
    {
        readonly ApplicationDbContext context;
        public CommonRepo(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<CountryModel> GetCountries()
        {
            List<CountryModel> result = new List<CountryModel>();
            result.AddRange(context.Countries.Select(x => x.AutoMap<CountryModel>()).ToList());
            return result;
        }
        public List<StateModel> GetStatesByCountryId(int countryId)
        {
            return context.States.Where(x => x.CountryId == countryId).Select(x => x.AutoMap<StateModel>()).ToList();
        }
        public List<CityModel> GetCitiesByStateId(int stateId)
        {
            return context.Cities.Where(x => x.StateId == stateId).Select(x => x.AutoMap<CityModel>()).ToList();
        }
        public PaymentTypeModel GetPaymentModel(int programId)
        {
            PaymentTypeModel result = new PaymentTypeModel();
            var paymentType= context.Programs.FirstOrDefault(x => x.Id == programId);
            if (paymentType != null)
            {
                result.Id = programId;
                result.Name = paymentType.Name;
                result.Description = paymentType.Description;
                result.Amount = paymentType.Amount;
                result.PaymentContent = paymentType.PaymentContent;
            }
            return result;

        }
    }
}
