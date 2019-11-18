using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace NamekWebPes.App_Start
{
    public class AuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //if (filterContext.HttpContext.Session["USER_SESSION"] != null)
            //{
            //    //Lay ra contronller hien tai
            //    string ControllerName = filterContext.Controller.ToString();
            //    LoginUserModels user = (LoginUserModels)filterContext.HttpContext.Session["USER_SESSION"];
            //    //Kiem tra xem List Action cua User co Controller hien tai khong
            //    //Co thi cho dung// khong co nghi de quay ve home
            //}
            ////else
            ////{
            ////Chuyen ve trang dang nhap
            //var routeValues = new RouteValueDictionary();
            //routeValues["controller"] = "Login";
            //routeValues["action"] = "Index";
            //filterContext.Result = new RedirectToRouteResult(routeValues);
            ////}

        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            //{
            //    filterContext.Result = new ViewResult
            //    {
            //        ViewName = "Error"
            //    };
            //}
        }
    }
}