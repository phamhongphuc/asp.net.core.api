using System.ComponentModel.DataAnnotations;
using blog.server.Models;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountLoginRequest : BaseDataTransfers<Account, AccountLoginRequest>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
