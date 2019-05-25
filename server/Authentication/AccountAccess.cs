using Microsoft.AspNetCore.Authorization;
using server.Models;
using server.Models.Enums;

namespace server.Authentication
{
    public class AccountAccess : IAuthorizationRequirement
    {
        private EnumAccess Roles { get; }

        public AccountAccess(EnumAccess roles) { Roles = roles; }

        public bool IsAllow(Account account) => Roles.HasFlag(account.Access);
    }
}
