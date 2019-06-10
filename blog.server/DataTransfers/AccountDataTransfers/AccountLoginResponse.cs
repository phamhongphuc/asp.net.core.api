using System.ComponentModel.DataAnnotations;

namespace blog.server.DataTransfers.AccountDataTransfers
{
    public class AccountLoginResponse
    {
        public AccountLoginResponse(string token) { Token = token; }

        [Required]
        public string Token { get; set; }
    }
}
