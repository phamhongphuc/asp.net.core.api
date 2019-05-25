using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using server.Businesses;
using server.Controllers;
using server.Middleware;

namespace server.Authentication
{
    public class AccountAccessHandler : AuthorizationHandler<AccountAccess>
    {
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AccountAccess requirement
        )
        {
            if (
                context.Resource is AuthorizationFilterContext ctx &&
                ctx.ActionDescriptor is ControllerActionDescriptor descriptor &&
                !IsValid(context, requirement)
            )
            {
                var response = new ErrorResponse
                {
                    Description = "Bạn không có quyền truy cập mục này",
                    Action = descriptor.ActionName,
                    Model = descriptor.ControllerName
                };
                ctx.Result = new ObjectResult(response);
                ctx.HttpContext.Response.StatusCode = 403;
            }
            context.Succeed(requirement);
            await Task.Yield();
        }

        private static bool IsValid(AuthorizationHandlerContext context, AccountAccess requirement)
        {
            var account = context.User.Account();
            if (account == null) return false;
            return requirement.IsAllow(account);
        }
    }
}
