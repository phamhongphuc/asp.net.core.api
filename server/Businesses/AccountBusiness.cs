using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Authentication;
using server.DataAccesses;
using server.DataTransfers.AccountDataTransfers;
using server.Middleware.Error;
using server.Models;
using server.Models.Enums;

namespace server.Businesses
{
    public static class AccountBusiness
    {
        private static void IsValid(this Account account)
        {
            if (account.Name.Length < 3)
                throw new Error400BadRequest<Account>(
                    "Tên phải có ít nhất 3 kí tự"
                );
        }

        public static IQueryable<Account> List => AccountDataAccess.List;

        public static Account Get(int id)
        {
            var account = AccountDataAccess.Get(id);
            if (account == null) throw new Error404NotFound<Account>(id);

            return account;
        }

        public static Account GetByEmail(string email) => AccountDataAccess.GetByEmail(email);

        public static async Task ChangePassword(Account account, AccountChangePasswordRequest request)
        {
            if (!account.IsEqualPassword(request.Password))
                throw new Error400BadRequest<Account>("Mật khẩu không chính xác");

            if (request.Password == request.NewPassword)
                throw new Error400BadRequest<Account>("Mật khẩu mới không được trùng");

            var newPassword = CryptoHelper.Encrypt(request.NewPassword);

            await AccountDataAccess.ChangePassword(account, newPassword);
        }

        public static async Task<Account> Update(Account accountInDatabase, Account account)
        {
            account.IsValid();
            return await AccountDataAccess.Update(accountInDatabase, account);
        }

        public static async Task UpdateAccess(AccountUpdateAccessRequest request)
        {
            var account = ((Account)request.Account).GetManaged;
            var access = account.Access;
            var newAccess = request.Access;

            if (newAccess == access)
                throw new Error400BadRequest<Account>("Tài khoản này đã được phân quyền là " + access);

            await AccountDataAccess.UpdateAccess(account, newAccess);
        }

        public static async Task<Account> Register(Account account)
        {
            if (account.IsPresent)
                throw new Error400BadRequest<Account>("Email " + account.Email + " đã có người sử dụng");

            account.IsValid();
            account.Password = CryptoHelper.Encrypt(account.Password);

            return await AccountDataAccess.Add(account);
        }

        public static AccountLoginResponse Login(Account accountRequest)
        {
            var account = accountRequest.GetManagedByEmail;
            if (account == null || !account.IsEqualPassword(accountRequest.Password))
                throw new Error400BadRequest<Account>("Tài khoản hoặc mật khẩu không chính xác");

            return new AccountLoginResponse(AuthorizationHelper.TokenBuilder(accountRequest.Email));
        }
    }
}
