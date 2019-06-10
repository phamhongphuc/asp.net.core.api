using System.ComponentModel.DataAnnotations;
using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateAccessRequest
    {
        [Required]
        public AccountIdTransfer Account { get; set; }

        [Required]
        public EnumAccess Access { get; set; }
    }
}
