using System.ComponentModel.DataAnnotations;
using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountCreateRequest : BaseDataTransfers<Account, AccountCreateRequest>
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public EnumGender Gender { get; set; }
    }
}
