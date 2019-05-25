using System;
using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountResponse : BaseDataTransfers<Account, AccountResponse>
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public EnumAccess Access { get; set; }
        public EnumGender Gender { get; set; }
        public DateTimeOffset Joined { get; set; }
    }
}
