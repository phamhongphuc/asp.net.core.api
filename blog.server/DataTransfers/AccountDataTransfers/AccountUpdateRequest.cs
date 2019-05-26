using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateRequest : BaseDataTransfers<Account, AccountUpdateRequest>
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public EnumGender Gender { get; set; }
    }
}
