using System;
using System.ComponentModel.DataAnnotations;
using blog.server.Models;
using blog.server.Models.Enums;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountResponse : BaseDataTransfers<Account, AccountResponse>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public EnumAccess Access { get; set; }

        [Required]
        public EnumGender Gender { get; set; }

        [Required]
        public DateTimeOffset Joined { get; set; }
    }
}
