using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateAccessRequest
    {
        public AccountIdTransfer Account { get; set; }
        public EnumAccess Access { get; set; }
    }
}
