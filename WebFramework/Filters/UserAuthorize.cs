using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Security.Claims;
using System.Threading;

namespace WebFramework.Filters
{
    public class UserAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var action = filterContext.ActionDescriptor.ActionName;
            //var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            //var claim = $"{controller.ToLower()}_{action.ToLower()}";
            //if (!identity.HasClaim("RolePermission", claim) && !identity.HasClaim("UsersPermission", claim))
            //    filterContext.Result = new RedirectResult("~/Error/AccessDenied");
        }
    }
}
