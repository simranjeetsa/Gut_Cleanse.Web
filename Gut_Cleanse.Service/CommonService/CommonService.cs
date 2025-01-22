using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.Common;
using Microsoft.AspNetCore.Http;

namespace Gut_Cleanse.Service.CommonService
{
    public class CommonService : ICommonService
    {
        readonly ICommonRepo commonRepo;
        readonly IHttpContextAccessor _httpContextAccessor;
        public CommonService(ICommonRepo _commonRepo, IHttpContextAccessor httpContextAccessor)
        {
            commonRepo = _commonRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<CountryModel> GetCountries()
        {
            return commonRepo.GetCountries();
        }
        public List<StateModel> GetStatesByCountryId(int countryId)
        {
            return commonRepo.GetStatesByCountryId(countryId);
        }
        public List<CityModel> GetCitiesByStateId(int stateId)
        {
            return commonRepo.GetCitiesByStateId(stateId);
        }
        public PaymentTypeModel GetPaymentTypeId(int paymentTypeId)
        {
            return commonRepo.GetPaymentTypeId(paymentTypeId);
        }
        public UserModel GetCurrentUserInfo()
        {
            UserModel model = new UserModel();
            if (_httpContextAccessor.HttpContext.Session.Keys.Count() > 0)
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(_httpContextAccessor.HttpContext.Session.GetString("User"));
            return model;
        }
    }
}
