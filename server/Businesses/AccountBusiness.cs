using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Authentication;
using server.DataAccesses;
using server.DataTransfers.AccountDataTransfers;
using server.Middleware.Error;
using server.Models;

namespace server.Businesses
{
    public static class AccountBusiness
    {
        public static IQueryable<Account> List => AccountDataAccess.List;

        public static Account Get(int id)
        {
            var account = AccountDataAccess.Get(id);
            if (account == null) throw new Error404NotFound<Account>(id);

            return account;
        }

        public static Account GetByEmail(string email) => AccountDataAccess.GetByEmail(email);

        private static void CheckValid(Account account)
        {
            // kiểm tra name, pass, email
            if (account.Name.Length < 3)
                throw new Error400BadRequest<Account>(
                    "Tên phải có ít nhất 3 kí tự"
                );

        }

        public static async Task<Account> Add(Account account)
        {
            var accountInDatabase = GetByEmail(account.Email);
            if (accountInDatabase != null)
                throw new Error400BadRequest<Account>("Email " + account.Email + " đã có người sử dụng");

            CheckValid(account);
            account.Pass = CryptoHelper.Encrypt(account.Pass);

            return await AccountDataAccess.Add(account);
        }

        public static async Task ChangePassword(Account accountInDatabase, AccountPasswordRequest account)
        {
            if (!accountInDatabase.IsEqualPassword(account.Pass))
                throw new Error400BadRequest<Account>("Mật khẩu không chính xác");

            if (account.Pass == account.NewPass)
                throw new Error400BadRequest<Account>("Mật khẩu mới không được trùng");

            var newPass = CryptoHelper.Encrypt(account.NewPass);

            await AccountDataAccess.ChangePassword(accountInDatabase, newPass);
        }

        public static async Task<Account> Update(Account accountInDatabase, Account account)
        {
            CheckValid(account);

            return await AccountDataAccess.Update(accountInDatabase, account);
        }

        public static AccountLoginResponse GetAuthenticationObject(AccountLoginRequest account)
        {
            var accountInDatabase = AccountDataAccess.GetByEmail(account.Email);
            if (accountInDatabase == null || !accountInDatabase.IsEqualPassword(account.Pass))
                throw new Error400BadRequest<Account>("Tài khoản hoặc mật khẩu không chính xác");

            return new AccountLoginResponse
            {
                Token = AuthenticationHelper.TokenBuilder(account.Email),
            };
        }
    }
}