using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gut_Cleanse.Web.Helpers
{
    public class CheckSessionIsAvailable : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext == null || filterContext.HttpContext.Session.GetString("User") == null)
            {
                //return RedirectToAction("Index", "Login");

                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Login",
                    ReturnUrl = "/" + filterContext.RouteData.Values["controller"].ToString() + "/" + filterContext.RouteData.Values["action"].ToString()
            }));
        }
    }

}
}
