using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Proj9.AuthorizationProvider
{
    public class AuthorizeAdmin : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("AccountType") != null && filterContext.HttpContext.Session.GetString("AccountType") == "Admin" || filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            else
            {
                //filterContext.Result = new  RedirectToRouteResult( //Specific routing setting
                //                new RouteValueDictionary(
                //                    new
                //                    {
                //                        controller = "Accounts",
                //                        action = "Index",
                //                        area = "admin"
                //                    })
                //                );                         
                filterContext.Result = new RedirectToActionResult("Index", "", ""); // Default routing setting
            }

        }
    }
}