using System.ComponentModel.DataAnnotations;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountChangePasswordRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
