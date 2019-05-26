using blog.server.Models;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountLoginRequest : BaseDataTransfers<Account, AccountLoginRequest>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
