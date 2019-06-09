using System.ComponentModel.DataAnnotations;
using blog.server.Models;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountIdTransfer : BaseDataTransfers<Account, AccountIdTransfer>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
