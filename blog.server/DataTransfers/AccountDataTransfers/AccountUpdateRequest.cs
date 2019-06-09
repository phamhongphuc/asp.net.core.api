using System.ComponentModel.DataAnnotations;
using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountUpdateRequest : BaseDataTransfers<Account, AccountUpdateRequest>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public EnumGender Gender { get; set; }
    }
}
