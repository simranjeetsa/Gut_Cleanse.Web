using Gut_Cleanse.Model;
using Gut_Cleanse.Repo.Common;

namespace Gut_Cleanse.Service.CommonService
{
    public class CommonService: ICommonService
    {
        readonly ICommonRepo commonRepo;
        public CommonService(ICommonRepo _commonRepo)
        {
            commonRepo = _commonRepo;
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
    }
}
