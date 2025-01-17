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
            result.Add(new CountryModel { Id = 0, Name = "-- Choose Country --" });
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
    }
}
