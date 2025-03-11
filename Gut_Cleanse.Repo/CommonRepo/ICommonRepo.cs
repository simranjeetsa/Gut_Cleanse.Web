using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Repo.Common
{
    public interface ICommonRepo
    {
        List<CountryModel> GetCountries();
        List<StateModel> GetStatesByCountryId(int countryId);
        List<CityModel> GetCitiesByStateId(int stateId);
        PaymentTypeModel GetPaymentModel(int programId);
        bool IsEbookAccess(int programId, int userId);
    }
}
