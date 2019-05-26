using blog.server.Models;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountIdTransfer : BaseDataTransfers<Account, AccountIdTransfer>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
