using server.Models;

namespace server.DataTransfers.AccountDataTransfers
{
    public class AccountIdResponse : BaseDataTransfers<Account, AccountIdResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
