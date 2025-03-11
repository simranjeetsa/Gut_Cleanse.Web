using Gut_Cleanse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gut_Cleanse.Service.CommonService
{
    public interface ICommonService
    {
        List<CountryModel> GetCountries();
        List<StateModel> GetStatesByCountryId(int countryId);
        List<CityModel> GetCitiesByStateId(int stateId);
        PaymentTypeModel GetPaymentModel(int programId);
        UserModel GetCurrentUserInfo();
        bool IsEbookAccess(int programId,int userId);
    }
}
