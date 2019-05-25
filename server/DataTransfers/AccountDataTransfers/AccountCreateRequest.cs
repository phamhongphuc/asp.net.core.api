using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountCreateRequest : BaseDataTransfers<Account, AccountCreateRequest>
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public EnumGender Gender { get; set; }
    }
}
