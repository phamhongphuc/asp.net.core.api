using server.Models;
using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateRequest : BaseDataTransfers<Account, AccountUpdateRequest>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public EnumGender Gender { get; set; }
    }
}