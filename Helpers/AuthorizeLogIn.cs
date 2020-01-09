

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Helpers
{
    public class AuthorizeLogIn : ActionFilterAttribute
    {
        private readonly string _Role;
        public AuthorizeLogIn(string Role)
        {
            this._Role = Role;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AppSession.CurrentUser == null||AppSession.CurrentUser.Role!=_Role)
                filterContext.Result = new RedirectResult("~/Account/LogIn");
        }
    }
}
