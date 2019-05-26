using Microsoft.AspNetCore.Authorization;
using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.Authentication
{
    public class AccountAccess : IAuthorizationRequirement
    {
        private EnumAccess Roles { get; }

        public AccountAccess(EnumAccess roles) { Roles = roles; }

        public bool IsAllow(Account account) => Roles.HasFlag(account.Access);
    }
}
