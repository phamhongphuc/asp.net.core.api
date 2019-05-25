using server.Models.Enums;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateAccessRequest
    {
        public AccountIdTransfer Account { get; set; }
        public EnumAccess Access { get; set; }
    }
}