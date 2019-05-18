using System;
using System.Linq;
using System.Threading.Tasks;
using server.DataAccesses.Base;
using server.Models;
using server.Models.Enums;

namespace server.DataAccesses
{
    public class AccountDataAccess : ModelHasIdDataAccess<Account>
    {
        public static Account GetByEmail(string email)
        {
            var x = List.Where(account => account.Email == email);
            if (x.Count() == 0) return null;
            return x.First();
        }

        public static async Task<Account> Add(Account account)
        {
            await Database.WriteAsync(realm =>
            {
                account.Id = NextId;
                account.Access = EnumAccess.NormalUser;
                account.Joined = DateTimeOffset.Now;
                account = realm.Add(account);
            });
            return account;
        }

        public static async Task ChangePassword(Account accountInDatabase, string newPass)
        {
            await Database.WriteAsync(realm => accountInDatabase.Pass = newPass);
        }

        public static async Task<Account> Update(Account accountInDatabase, Account account)
        {
            await Database.WriteAsync(realm =>
            {
                accountInDatabase.Name = account.Name;
                accountInDatabase.Picture = account.Picture;
                accountInDatabase.Gender = account.Gender;
            });
            return accountInDatabase;
        }
    }
}
