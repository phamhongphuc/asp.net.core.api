using server.Models;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountPasswordRequest : BaseDataTransfers<Account, AccountPasswordRequest>
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string NewPass { get; set; }
    }
}