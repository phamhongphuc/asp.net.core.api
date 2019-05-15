using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountRequest : BaseDataTransfers<Account, AccountRequest>
    {
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public EnumGender Gender { get; set; }
    }
}