using System.Linq;
using System.Security.Claims;
using blog.server.Businesses;
using blog.server.Middleware.Error;
using blog.server.Models;

namespace blog.server.Authentication
{
    public static class ContextHelper
    {
        public static Account Account(this ClaimsPrincipal User)
            => AccountBusiness.GetByEmail(User.Email());

        public static string Email(this ClaimsPrincipal User)
        {
            if (User.Claims.Count() == 0)
                throw new Error401Unauthorized<Account>("Không tìm thấy dữ liệu trong token");
            return User.Claims.First(i => i.Type == ClaimTypes.Email).Value;
        }
    }
}

