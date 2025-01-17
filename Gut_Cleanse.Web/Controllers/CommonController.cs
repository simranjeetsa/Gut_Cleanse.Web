using Gut_Cleanse.Service.CommonService;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Controllers
{
    public class CommonController : Controller
    {
        readonly ICommonService commonService;
        public CommonController(ICommonService _commonService)
        {
            commonService= _commonService;
        }
        [HttpGet]
        public IActionResult GetStatesByCountryId(int countryId)
        {
            return Json(commonService.GetStatesByCountryId(countryId));
        }

        [HttpGet]
        public IActionResult GetCitiesByStateId(int stateId)
        {
            return Json(commonService.GetCitiesByStateId(stateId));
        }
    }
}
