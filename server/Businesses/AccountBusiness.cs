using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var accountInDatabase = AccountDataAccess.GetByEmail(account.Email);
            if (accountInDatabase != null) throw new Exception("Email " + account.Email + " đã có người sử dụng");

            CheckValid(account);
            return await AccountDataAccess.Add(account);
        }

        public static async Task ChangePassword(AccountPasswordRequest account)
        {
            var accountInDatabase = AccountDataAccess.GetByEmail(account.Email);
            if (accountInDatabase == null) throw new Exception("Tài khoản không tồn tại");
            if(accountInDatabase.Pass != account.Pass) throw new Exception("Mật khẩu không chính xác");

            await AccountDataAccess.ChangePassword(accountInDatabase, account.NewPass);
        }
    }
}